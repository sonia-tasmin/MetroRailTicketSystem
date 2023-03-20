
namespace Shared.Security;

public class AuthorizeAttribute : Attribute
{
    public AuthorizeAttribute() { }

    /// <summary>
    /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
    /// </summary>
    public string Roles { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the policy name that determines access to the resource.
    /// </summary>
    public string Policy { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the permissions name that determines access to the resource.
    /// </summary>
    public string Permissions { get; set; } = string.Empty;
}
