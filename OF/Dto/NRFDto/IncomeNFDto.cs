using System;
namespace OF.Dto.NRFDto
{
    public class IncomeNFDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public IncomeLocationDto Location { get; set; }
        public ICollection<IncomeServiceDto> Services { get; set; }
        public float BusyIndex { get; set; }
        public string state { get; set; }
        public string SuscriptionApi { get; set; }
    }
}

