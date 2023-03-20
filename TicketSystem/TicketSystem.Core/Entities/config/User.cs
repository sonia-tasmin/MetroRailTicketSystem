using TicketSystem.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketSystem.Core.Entities;

[Table("User", Schema = "config")]
public class User : BaseEntity<Guid>
{
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(30)]
    public string Email { get; set; }
    [MaxLength(30)]
    public string Password { get; set; }
    [MaxLength(30)]
    public string UserType { get; set; }

    [Required]
    public bool UserTypeStatus { get; set; }


}
