using TicketSystem.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketSystem.Core.Entities;

[Table("Route", Schema = "config")]
public class Route : BaseEntity<Guid>
{
    [MaxLength(30)]
    public string RouteName { get; set; }

}

