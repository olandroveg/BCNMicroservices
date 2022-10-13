using System;
namespace UDRF.Models
{
    public class Place
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ICollection<BcNode> BcNodes { get; set; }
    }
}

