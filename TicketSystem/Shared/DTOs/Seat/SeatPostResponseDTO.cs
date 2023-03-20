namespace Shared.DTOs.Seat
{
    public class SeatPostResponseDTO
    {
        public Guid Id { get; set; }
        public string SeatName { get; set; }
        public float Price { get; set; }
        public bool Ordered { get; set; }
        public Guid RouteTrainId { get; set; }

    }
}
