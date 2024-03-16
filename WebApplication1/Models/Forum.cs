namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class Forum
    {
        public int ID_Post { get; set; }
        public string Title_Post { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
