using API.Models;

namespace API.DataAccess
{
    public interface IDataAccess
    {
        int CreateUser(User user);
        bool IsEmailAvailable(string email);
        bool AuthenticateUser(string email, string password, out User? user);
        IList<Seat> GetAllSeats();
        void ActiveRoute(int trainId);
        void InactiveRoute(int trainId);
        bool OrderSeat(int userId, int seatId);
        IList<Order> GetOrdersOfUser(int userId);
        IList<Order> GetAllOrders();
        bool ReturnSeat(int userId, int seatId);
        IList<User> GetUsers();
        IList<RouteTrain> GetAllTrains();
        void InsertNewSeat(Seat seat);
        bool DeleteSeat(int seatId);
        void CreateTrain(RouteTrain seatTrain);
    }
}
