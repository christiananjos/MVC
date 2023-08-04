using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Log : Base
    {
        public Log(string description, string user)
        {
            Description = description;
            User = user;
        }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "User")]
        public string User { get; set; }
    }
}
