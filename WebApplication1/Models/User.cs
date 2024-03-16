using Microsoft.AspNetCore.Identity;

namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class User:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Password { get; set;}
        public string permission { get; set; }
        public string Location { get; set; }
        public List<News> News { get; set; }
        public List<Forum> Forums { get; set; }
        public List<Product_Recycle> product_Recycles { get; set; }
        public List<Assignment> Assignments { get; set; }

    }
}
