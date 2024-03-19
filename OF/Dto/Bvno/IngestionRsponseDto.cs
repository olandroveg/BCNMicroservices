using System;
namespace OF.Dto.Bvno
{
	public class IngestionRsponseDto
	{
		public IngestionRsponseDto()
		{
		}
		public bool isAccepted { get; set; }
        public IngestionMode ingestionMode { get; set; }
        public string SchedduleTime { get; set; }
        public IEnumerable<string> ChannelList { get; set; }
        public string Resolution { get; set; }
    }
}

