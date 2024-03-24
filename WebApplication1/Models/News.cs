namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class News
    {
        public int Id_New { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created_at { get; set; }
        public string Created_by { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
