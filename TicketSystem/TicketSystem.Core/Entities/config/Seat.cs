using TicketSystem.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketSystem.Core.Entities;

[Table("Seat", Schema = "config")]
public class Seat : BaseEntity<Guid>
{
    [MaxLength(30)]
    public string SeatName { get; set; }
    [MaxLength(30)]
    public float Price { get; set; }

    [Required]
    public bool Ordered { get; set; }
    //public string TrainName { get; set; }

    public Guid RouteTrainId { get; set; }
    [ForeignKey("RouteTrainId")]
    public virtual RouteTrain RouteTrain { get; set; }
    [NotMapped]
    public string TrainName { get; set; }
    [NotMapped]
    public string RouteName { get; set; }

}

