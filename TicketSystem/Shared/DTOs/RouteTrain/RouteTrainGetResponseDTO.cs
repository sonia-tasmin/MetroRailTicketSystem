namespace Shared.DTOs.RouteTrain
{
    public class RouteTrainGetResponseDTO
    {
        public Guid Id { get; set; }
        public Guid TrainId { get; set; }
        public string TrainName { get; set; }
        public Guid RouteId { get; set; }
        public string RouteName { get; set; }
        public bool Active { get; set; }
    }
}
