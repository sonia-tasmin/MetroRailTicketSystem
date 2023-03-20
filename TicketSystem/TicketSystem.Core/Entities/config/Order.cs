using TicketSystem.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketSystem.Core.Entities;

[Table("Order", Schema = "config")]
public class Order : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    [MaxLength(30)]
    //public string Name { get; set; }
    public Guid SeatId { get; set; }

    [MaxLength(30)]
    //public string Seat { get; set; }

    public DateTime OrderDate { get; set; }
    public int Returned { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    [ForeignKey("SeatId")]
    public virtual Seat Seat { get; set; }
    [NotMapped]
    public string UserName { get; set; }
    [NotMapped]
    public string SeatName { get; set; }

}

