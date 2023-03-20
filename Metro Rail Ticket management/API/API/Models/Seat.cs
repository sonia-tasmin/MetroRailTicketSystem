namespace API.Models
{
    public class Seat : ModelBase
    {
        public string SeatName { get; set; } = string.Empty;
        public float Price { get; set; } = 0;
        public bool Ordered { get; set; } = false;
        public int TrainId { get; set; }
        public RouteTrain Train { get; set; } = new RouteTrain();
    }
}
