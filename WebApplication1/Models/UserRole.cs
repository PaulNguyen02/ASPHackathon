using Microsoft.AspNetCore.Identity;

namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class UserRole:IdentityRole<Guid>
    {
    
      
        public string Description { get; set; }
    }
}
