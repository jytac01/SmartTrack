using System.ComponentModel.DataAnnotations;

namespace SmartTrack.Models
{
    public class Class
    {
        public Guid ClassId { get; set; }

        public string Teacher { get; set; }
        public string Subject { get; set; }
        public string Room { get; set; }

        public TimeOnly ClassTime { get; set; }
        public string ClassDay { get; set; }
    }
}
