using System;
namespace UDRF.Models
{
    public class InterfaceBcNode
    {
        public Guid Id { get; set; }
        public Guid InterfaceId { get; set; }
        public Interfaces Interfaces { get; set; }
        public Guid BcNodeId { get; set; }
        public BcNode BcNode { get; set; }
    }
}

