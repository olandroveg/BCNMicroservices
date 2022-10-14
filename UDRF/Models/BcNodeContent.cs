namespace UDRF.Models
{
    public class BcNodeContent
    {
        public Guid Id { get; set; }
        public Guid BcNodeId { get; set; }
        public BcNode Bcnode { get; set; }
        public Guid ContentId { get; set; }
        public Content Content { get; set; }
        public float Bitrate { get; set; }
        public float Size { get; set; }
        public ICollection<TimeSchedule> TimeSchedules { get; set; }
    }
}
