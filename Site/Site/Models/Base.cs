namespace Site.Models
{
    public class Base
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
