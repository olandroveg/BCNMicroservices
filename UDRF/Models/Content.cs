namespace UDRF.Models
{
    public class Content
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SourceLocation { get; set; }
        public ICollection<BcNodeContent> BcNodeContents { get; set; }
        public Guid ServicesId { get; set; }
        //public ContentServices Services { get; set; }
    }
}
