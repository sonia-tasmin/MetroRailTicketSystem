using TicketSystem.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketSystem.Core.Entities;

[Table("RouteTrain", Schema = "config")]
public class RouteTrain : BaseEntity<Guid>
{

    public Guid TrainId { get; set; }
    public Guid RouteId { get; set; }

    [Required]
    public bool Active { get; set; }
    [ForeignKey("TrainId")]
    public virtual Train Train { get; set; }
    [ForeignKey("RouteId")]
    public virtual Route Route { get; set; }
    [NotMapped]
    public string TrainName { get; set; }
    [NotMapped]
    public string RouteName { get; set; }
}

