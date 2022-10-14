using System;
namespace UDRF.Models
{
    public class Interfaces
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<InterfaceBcNode> InterfaceBcNodes { get; set; }
    }
}

