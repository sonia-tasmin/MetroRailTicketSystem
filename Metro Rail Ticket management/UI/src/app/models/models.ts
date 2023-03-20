export interface SideNavItem {
  title: string;
  link: string;
}

export enum UserType {
  ADMIN,
  USER,
}

export interface User {
  id: number;
  name: string;
  email: string;
  password: string;
  createdOn: string;
  userType: UserType;
}

export interface Seat {
  id: number;
  seatName: string;
  route: string;
  train: string;
  price: number;
  available: boolean;
  count?: number;
}

export interface RouteSeats {
  id: number
  route: string;
  train: string;
  seats: Seat[];
  active: boolean;
}

export interface Order {
  id: number;
  userid: number;
  name: string;
  seatid: number;
  seattitle: string;
  orderedon: string;
  returned: boolean;
}

export interface Route {
  id: number
  name: string;
  children?: Route[];
  active: boolean;
}
