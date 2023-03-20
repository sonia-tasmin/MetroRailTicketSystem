namespace Shared.DTOs.Order
{
    public class OrderGetResponseDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid SeatId { get; set; }
        public string SeatName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Returned { get; set; }

    }
}
