namespace Shared.DTOs.RouteTrain
{
    public class RouteTrainPostResponseDTO
    {
        public Guid Id { get; set; }
        public Guid TrainId { get; set; }
        public Guid RouteId { get; set; }
        public bool Active { get; set; }
    }
}
