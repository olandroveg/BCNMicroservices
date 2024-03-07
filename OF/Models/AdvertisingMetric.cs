namespace OF.Models
{
    public class AdvertisingMetric
    {
        public string category { get; set; }
        public int payment { get; set; }
        public int alreadShown { get; set; }
        public int visualTime { get; set; }
        public int socialContext { get; set; }
        public int weigthSum => payment + alreadShown + visualTime + socialContext;
        public AdvertisingMetric() { }
    }
}
