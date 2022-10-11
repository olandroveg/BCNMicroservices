using System;
namespace UDRF.Models
{
    public class ContentServices
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool RealTime { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}

