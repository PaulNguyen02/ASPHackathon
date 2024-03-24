using Microsoft.AspNetCore.Identity;

namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class UserRole:IdentityRole
    {
    public string Description { get; set; }
    }
}
