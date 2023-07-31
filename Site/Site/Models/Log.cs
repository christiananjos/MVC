namespace Site.Models
{
    public class Log : Base
    {
        public Log(string description, string user)
        {
            Description = description;
            User = user;
        }

        public string Description { get; set; }
        public string User { get; set; }
    }
}
