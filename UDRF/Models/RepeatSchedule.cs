using System;
namespace UDRF.Models
{
    public class RepeatSchedule
    {
        public Guid Id { get; set; }
        public Guid TimeSchduleId { get; set; }
        public TimeSchedule TimeSchedule { get; set; }
        public DateTime DateTime { get; set; }
    }
}

