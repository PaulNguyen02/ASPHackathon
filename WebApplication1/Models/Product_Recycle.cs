namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class Product_Recycle
    {
        public int ID_Product { get; set; }
        public string Product_Name { get; set; }
        public string Decription { get; set; }
        public string Organic { get; set; }
        public string Inorganic { get; set; }
        public string Recycling { get; set; }
        public string Place { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
