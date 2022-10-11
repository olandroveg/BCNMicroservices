namespace UDRF.Models
{
    public class BcNode
    {
        public Guid Id { get; set; }
        public Guid? TopBcNodeId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfSecondBcNodes { get; set; }
        public ICollection<BcNode> SecondaryBcNodes { get; set; }
        public bool Ready { get; set; }
        public int Group { get; set; }
        public ICollection<BcNodeContent> BcNodeContents { get; set; }
        //public ICollection<InterfaceBcNode> InterfaceBcNodes { get; set; }
        //public ICollection<InterfaceBcNodesCoreBcNode> InterfaceBcNodesCoreBcNodes { get; set; }
    }
}
