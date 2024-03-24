namespace WebEnvironment_Hackathon_GaMo.Models
{
    public class EmailData
    {
        public string From { get; set; }

        public string? To { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public string Password { get; set; }

        public EmailData()
        {
            From = "chibaodang2002@gmail.com";
            Password = "viol ynww jwca kmrm";
        }
    }
}
