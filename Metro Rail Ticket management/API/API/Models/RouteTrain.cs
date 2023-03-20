namespace API.Models
{
    public class RouteTrain : ModelBase
    {
        public string Train { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public bool Active { get; set; } = false;

    }
}
