namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class Assignment
    {
        public int Order_num { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Id_Mission { get; set; }
    }
}
