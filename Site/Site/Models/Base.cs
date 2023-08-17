using System.Text.Json.Serialization;

namespace Site.Models
{
    public class Base
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime? UpdateAt { get; set; }

        [JsonIgnore]
        public DateTime? RemovedAt { get; set; }
    }
}
