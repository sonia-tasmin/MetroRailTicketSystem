using API.DataAccess;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketingController : ControllerBase
    {
        private readonly IDataAccess ticketing;
        private readonly IConfiguration configuration;
        public TicketingController(IDataAccess ticketing, IConfiguration configuration = null)
        {
            this.ticketing = ticketing;
            this.configuration = configuration;
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(User user)
        {
            if (!ticketing.IsEmailAvailable(user.Email))
            {
                return Ok("Email is not available!");
            }
            user.CreatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            user.UserType = UserType.USER;
            ticketing.CreateUser(user);
            return Ok("Account created successfully!");
        }

        [HttpGet("Login")]
        public IActionResult Login(string email, string password)
        {
            if (ticketing.AuthenticateUser(email, password, out User? user))
            {
                if (user != null)
                {
                    var jwt = new Jwt(configuration["Jwt:Key"], configuration["Jwt:Duration"]);
                    var token = jwt.GenerateToken(user);
                    return Ok(token);
                }
            }
            return Ok("Invalid");
        }

        [HttpGet("GetAllSeats")]
        public IActionResult GetALlSeats()
        {
            var seats = ticketing.GetAllSeats();
            var seatsToSend = seats.Select(seat => new
            {
                seat.Id,
                seat.SeatName,
                seat.Train.Train,
                seat.Train.Route,
                seat.Price,
                Available = !seat.Ordered,
            }).ToList();
            return Ok(seatsToSend);
        }

        [HttpGet("OrderSeat/{userId}/{seatId}")]
        public IActionResult OrderSeat(int userId, int seatId)
        {
            var result = ticketing.OrderSeat(userId, seatId) ? "success" : "fail";
            return Ok(result);
        }

        [HttpGet("GetOrders/{id}")]
        public IActionResult GetOrders(int id)
        {
            return Ok(ticketing.GetOrdersOfUser(id));
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            return Ok(ticketing.GetAllOrders());
        }

        [HttpGet("ReturnSeat/{seatId}/{userId}")]
        public IActionResult ReturnSeat(string seatId, string userId)
        {
            var result = ticketing.ReturnSeat(int.Parse(userId), int.Parse(seatId));
            return Ok(result == true ? "success" : "not returned");
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = ticketing.GetUsers();
            var result = users.Select(user => new
            {
                user.Id,
                user.Name,
                user.Email,
                user.CreatedOn,
                user.UserType,
            });
            return Ok(result);
        }

        [HttpGet("GetAllTrains")]
        public IActionResult GetAllTrains()
        {
            var routexs = ticketing.GetAllTrains();
            var x = routexs.GroupBy(c => c.Train).Select(item =>
            {
                return new 
                { 
                    name = item.Key, 
                    children = item.Select(item => new { name = item.Route }).ToList() 
                };
            }).ToList();
            return Ok(x);
        }

        [HttpPost("InsertSeat")]
        public IActionResult InsertSeat(Seat seat)
        {
            seat.SeatName = seat.SeatName.Trim();
            seat.Train.Train = seat.Train.Train.ToLower();
            seat.Train.Route = seat.Train.Route.ToLower();

            ticketing.InsertNewSeat(seat);
            return Ok("Inserted");
        }

        [HttpDelete("DeleteSeat/{id}")]
        public IActionResult DeleteSeat(int id)
        {
            var returnResult = ticketing.DeleteSeat(id) ? "success" : "fail";
            return Ok(returnResult);
        }

        [HttpPost("InsertTrain")]
        public IActionResult InsertTrain(RouteTrain seatTrain)
        {
            seatTrain.Train = seatTrain.Train.ToLower();
            seatTrain.Route = seatTrain.Route.ToLower();
            ticketing.CreateTrain(seatTrain);
            return Ok("Inserted");
        }
        [HttpGet("GetRoutes")]
        public IActionResult GetRoutes()
        {
            return Ok(ticketing.GetAllTrains());
        }
        [HttpGet("ChangeActiveStatus/{status}/{id}")]
        public IActionResult ChangeActiveStatus(int status, int id)
        {
            if (status == 1)
            {
                ticketing.ActiveRoute(id);
            }
            else
            {
                ticketing.InactiveRoute(id);
            }
            return Ok("success");
        }
    }
}
