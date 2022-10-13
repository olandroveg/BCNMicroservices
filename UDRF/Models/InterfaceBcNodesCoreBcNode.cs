using System;
namespace UDRF.Models
{
    public class InterfaceBcNodesCoreBcNode
    {
        public Guid Id { get; set; }
        public Guid InterfBcNodeCoreId { get; set; }
        public InterfBcNodeCore InterfBcNodeCore { get; set; }
        public Guid BcNodeId { get; set; }
        public BcNode BcNode { get; set; }
    }
}

