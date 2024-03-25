using System.ComponentModel.DataAnnotations;

namespace ZettelKasten.Models.Requests;

public class UserRegistrationRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required] 
    public string Email { get; set; } = string.Empty;
    [Required] 
    public string Password { get; set; } = string.Empty;
}
