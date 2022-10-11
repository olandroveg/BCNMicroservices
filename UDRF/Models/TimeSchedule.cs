using System;
namespace UDRF.Models
{
    public class TimeSchedule
    {
        public Guid Id { get; set; }
        public Guid BcNodeContentId { get; set; }
        public BcNodeContent BcNodeContent { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationSec { get; set; }
        public ICollection<RepeatSchedule> RepeatSchedule { get; set; }
    }
}

