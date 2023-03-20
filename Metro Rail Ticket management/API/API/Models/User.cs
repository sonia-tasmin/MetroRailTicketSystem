namespace API.Models
{
    public class User : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserType UserType { get; set; }
        public string CreatedOn { get; set; } = string.Empty;
    }
}
