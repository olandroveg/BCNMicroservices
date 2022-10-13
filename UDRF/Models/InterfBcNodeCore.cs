using System;
namespace UDRF.Models
{
    public class InterfBcNodeCore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<InterfaceBcNodesCoreBcNode> InterfaceBcNodesCoreBcNode { get; set; }
    }
}

