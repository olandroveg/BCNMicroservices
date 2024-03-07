using System;
namespace OF.Models
{
    public class Token
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
        public DateTime DateTime { get; set; }
        public Guid BcnUserId { get; set; }
       
    }
}

