namespace Shared.DTOs.Seat
{
    public class SeatGetResponseDTO
    {
        public Guid Id { get; set; }
        public string SeatName { get; set; }
        public float Price { get; set; }
        public bool Ordered { get; set; }
        public string TrainName { get; set; }
        public string RouteName { get; set; }
        public Guid RouteTrainId { get; set; }

    }
}
