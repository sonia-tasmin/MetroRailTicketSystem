import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { Seat, Route, Order, User, UserType, RouteSeats } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  baseUrl = 'https://localhost:7038/api/Ticketing/';
  constructor(private http: HttpClient, private jwt: JwtHelperService) {}

  createAccount(user: User) {
    return this.http.post(this.baseUrl + 'CreateAccount', user, {
      responseType: 'text',
    });
  }

  login(loginInfo: any) {
    let params = new HttpParams()
      .append('email', loginInfo.email)
      .append('password', loginInfo.password);
    return this.http.get(this.baseUrl + 'Login', {
      params: params,
      responseType: 'text',
    });
  }

  saveToken(token: string) {
    localStorage.setItem('access_token', token);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('access_token');
  }

  deleteToken() {
    localStorage.removeItem('access_token');
    location.reload();
  }

  getTokenUserInfo(): User | null {
    if (!this.isLoggedIn()) return null;
    let token = this.jwt.decodeToken();
    let user: User = {
      id: token.id,
      name: token.name,
      email: token.email,
      password: '',
      createdOn: token.createdAt,
      userType: token.userType === 'USER' ? UserType.USER : UserType.ADMIN,
    };
    return user;
  }

  getAllSeats() {
    return this.http.get<Seat[]>(this.baseUrl + 'GetAllSeats');
  }

  orderSeat(userId: number, seatId: number) {
    return this.http.get(this.baseUrl + 'OrderSeat/' + userId + '/' + seatId, {
      responseType: 'text',
    });
  }

  getOrdersOfUser(userid: number) {
    return this.http.get<Order[]>(this.baseUrl + 'GetOrders/' + userid);
  }

  getAllOrders() {
    return this.http.get<Order[]>(this.baseUrl + 'GetAllOrders');
  }

  returnSeat(seatId: string, userId: string) {
    return this.http.get(this.baseUrl + 'ReturnSeat/' + seatId + '/' + userId, {
      responseType: 'text',
    });
  }

  getAllUsers() {
    return this.http.get<User[]>(this.baseUrl + 'GetAllUsers').pipe(
      map((users) =>
        users.map((user) => {
          let temp: User = user;
          temp.userType = user.userType == 0 ? UserType.USER : UserType.ADMIN;
          return temp;
        })
      )
    );
  }

  getTrains() {
    return this.http.get<Route[]>(this.baseUrl + 'GetAllTrains');
  }
  getRoutes() {
    return this.http.get<RouteSeats[]>(this.baseUrl + 'GetRoutes');
  }

  insertSeat(seat: any) {
    return this.http.post(this.baseUrl + 'InsertSeat', seat, {
      responseType: 'text',
    });
  }

  deleteSeat(id: number) {
    return this.http.delete(this.baseUrl + 'DeleteSeat/' + id, {
      responseType: 'text',
    });
  }

  insertTrain(route: string, train: string) {
    return this.http.post(
      this.baseUrl + 'InsertTrain',
      { route: route, train: train },
      { responseType: 'text' }
    );
  }
  activeRoute(id: number) {
    return this.http.get(this.baseUrl + 'ChangeActiveStatus/1/' + id, {
      responseType: 'text',
    });
  }

  InactiveRoute(id: number) {
    return this.http.get(this.baseUrl + 'ChangeActiveStatus/0/' + id, {
      responseType: 'text',
    });
  }

}
