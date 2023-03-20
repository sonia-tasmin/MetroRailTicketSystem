namespace Shared.DTOs.Order
{
    public class OrderPostResponseDTO
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        //public string Name { get; set; }
        public int SeatId { get; set; }
        //public string Seat { get; set; }
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }
    }
}
