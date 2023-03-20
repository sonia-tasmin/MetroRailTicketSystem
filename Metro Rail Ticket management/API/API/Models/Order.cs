namespace API.Models
{
    public class Order : ModelBase
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SeatId { get; set; }
        public string Seat { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }
    }
}
