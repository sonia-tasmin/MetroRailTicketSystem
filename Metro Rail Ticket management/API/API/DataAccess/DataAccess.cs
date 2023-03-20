using API.Models;
using Dapper;
using System.Data.SqlClient;

namespace API.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration configuration;
        private readonly string DbConnection;

        public DataAccess(IConfiguration _configuration)
        {
            configuration = _configuration;
            DbConnection = configuration["connectionStrings:DBConnect"] ?? "";
        }

        public int CreateUser(User user)
        {
            var result = 0;
            using (var connection = new SqlConnection(DbConnection))
            {
                var parameters = new
                {
                    n = user.Name,
                    em = user.Email,
                    pwd = user.Password,
                    con = user.CreatedOn,
                    type = user.UserType.ToString()
                };
                var sql = "insert into Users (Name, Email, Password, CreatedOn, UserType) values (@n,  @em, @pwd, @con, @type);";
                result = connection.Execute(sql, parameters);
            }
            return result;
        }

        public bool IsEmailAvailable(string email)
        {
            var result = false;

            using (var connection = new SqlConnection(DbConnection))
            {
                result = connection.ExecuteScalar<bool>("select count(*) from Users where Email=@email;", new { email });
            }

            return !result;
        }

        public bool AuthenticateUser(string email, string password, out User? user)
        {
            var result = false;
            using (var connection = new SqlConnection(DbConnection))
            {
                result = connection.ExecuteScalar<bool>("select count(1) from Users where email=@email and password=@password;", new { email, password });
                if (result)
                {
                    user = connection.QueryFirst<User>("select * from Users where email=@email;", new { email });
                }
                else
                {
                    user = null;
                }
            }
            return result;
        }

        public IList<Seat> GetAllSeats()
        {
            IEnumerable<Seat> seats = null;
            using (var connection = new SqlConnection(DbConnection))
            {
                var sql = @"SELECT  Seats.Id, Seats.SeatName, Seats.Price, Seats.Ordered, Seats.TrainId  FROM Seats  JOIN RouteTrains ON RouteTrains.Id = Seats.TrainId where RouteTrains.Active=1;";
                seats = connection.Query<Seat>(sql);

                foreach (var seat in seats)
                {
                    sql = "select * from RouteTrains where Id=" + seat.TrainId;
                    seat.Train = connection.QuerySingle<RouteTrain>(sql);
                }
            }
            return seats.ToList();
        }

        public bool OrderSeat(int userId, int seatId)
        {
            var ordered = false;

            using (var connection = new SqlConnection(DbConnection))
            {
                var sql = $"insert into Orders (UserId, SeatId, OrderedOn, Returned) values ({userId}, {seatId}, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 0);";
                var inserted = connection.Execute(sql) == 1;
                if (inserted)
                {
                    sql = $"update Seats set Ordered=1 where Id={seatId}";
                    var updated = connection.Execute(sql) == 1;
                    ordered = updated;
                }
            }

            return ordered;
        }

        public IList<Order> GetOrdersOfUser(int userId)
        {
            IEnumerable<Order> orders;
            using (var connection = new SqlConnection(DbConnection))
            {
                var sql = @"
                    select 
                        o.Id, 
                        u.Id as UserId, u.Name,
                        o.SeatId as SeatId, b.SeatName as Seat,
                        o.OrderedOn as OrderDate, o.Returned as Returned
                    from Users u LEFT JOIN Orders o ON u.Id=o.UserId
                    LEFT JOIN Seats b ON o.SeatId=b.Id
                    where o.UserId IN (@Id);
                ";
                orders = connection.Query<Order>(sql, new { Id = userId });
            }
            return orders.ToList();
        }

        public IList<Order> GetAllOrders()
        {
            IEnumerable<Order> orders;
            using (var connection = new SqlConnection(DbConnection))
            {
                var sql = @"
                    select 
                        o.Id, 
                        u.Id as UserId, u.Name,
                        o.SeatId as SeatId, b.SeatName as Seat,
                        o.OrderedOn as OrderDate, o.Returned as Returned
                    from Users u LEFT JOIN Orders o ON u.Id=o.UserId
                    LEFT JOIN Seats b ON o.SeatId=b.Id
                    where o.Id IS NOT NULL;
                ";
                orders = connection.Query<Order>(sql);
            }
            return orders.ToList();
        }

        public bool ReturnSeat(int userId, int seatId)
        {
            var returned = false;
            using (var connection = new SqlConnection(DbConnection))
            {
                var sql = $"update Seats set Ordered=0 where Id={seatId};";
                connection.Execute(sql);
                sql = $"update Orders set Returned=1 where UserId={userId} and SeatId={seatId};";
                returned = connection.Execute(sql) == 1;
            }
            return returned;
        }

        public IList<User> GetUsers()
        {
            IEnumerable<User> users;
            using (var connection = new SqlConnection(DbConnection))
            {
                users = connection.Query<User>("select * from Users;");

                var listOfOrders =
                    connection.Query("select u.Id as UserId, o.SeatId as SeatId, o.OrderedOn as OrderDate, o.Returned as Returned from Users u LEFT JOIN Orders o ON u.Id=o.UserId;");

                foreach (var user in users)
                {
                    var orders = listOfOrders.Where(lo => lo.UserId == user.Id).ToList();
                    foreach (var order in orders)
                    {
                        if (order.SeatId != null && order.Returned != null && order.Returned == false)
                        {
                            var orderDate = order.OrderDate;
                            var maxDate = orderDate.AddDays(10);
                            var currentDate = DateTime.Now;

/*                            var extraDays = (currentDate - maxDate).Days;
                            extraDays = extraDays < 0 ? 0 : extraDays;

                            fine = extraDays * 50;
                            user.Fine += fine;*/
                        }
                    }
                }
            }
            return users.ToList();
        }

        public IList<RouteTrain> GetAllTrains()
        {
            IEnumerable<RouteTrain> trains;

            using (var connection = new SqlConnection(DbConnection))
            {
                trains = connection.Query<RouteTrain>("select * from RouteTrains;");
            }

            return trains.ToList();
        }
        public void ActiveRoute(int trainId)
        {
            using var connection = new SqlConnection(DbConnection);
            connection.Execute("update RouteTrains set Active=1 where Id=@Id", new { Id = trainId });
        }

        public void InactiveRoute(int trainId)
        {
            using var connection = new SqlConnection(DbConnection);
            connection.Execute("update RouteTrains set Active=0 where Id=@Id", new { Id = trainId });
        }

        public void InsertNewSeat(Seat seat)
        {
            using var conn = new SqlConnection(DbConnection);
            var sql = "select Id from RouteTrains where Train=@trn and Route=@rut";
            var parameter1 = new
            {
                trn = seat.Train.Train,
                rut = seat.Train.Route
            };
            var trainId = conn.ExecuteScalar<int>(sql, parameter1);

            sql = "insert into Seats (SeatName, Price, Ordered, TrainId) values (@seatName, @price, @ordered, @trnid);";
            var parameter2 = new
            {
                seatName = seat.SeatName,
                price = seat.Price,
                ordered = false,
                trnid = trainId
            };
            conn.Execute(sql, parameter2);
        }

        public bool DeleteSeat(int seatId)
        {
            var deleted = false;
            using (var connection = new SqlConnection(DbConnection))
            {
                var sql = $"delete Seats where Id={seatId}";
                deleted = connection.Execute(sql) == 1;
            }
            return deleted;
        }

        public void CreateTrain(RouteTrain seatTrain)
        {
            using var connection = new SqlConnection(DbConnection);
            var parameter = new
            {
                trn = seatTrain.Train,
                rut = seatTrain.Route
            };
            connection.Execute("insert into RouteTrains (train, route) values (@trn, @rut);", parameter);
        }
    }
}
