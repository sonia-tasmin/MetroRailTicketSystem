using TicketSystem.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketSystem.Core.Entities;

[Table("Train", Schema = "config")]
public class Train : BaseEntity<Guid>
{
    [MaxLength(30)]
    public string TrainName { get; set; }

}

