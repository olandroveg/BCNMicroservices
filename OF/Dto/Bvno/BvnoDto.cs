using System;
namespace OF.Dto.Bvno
{
	public class BvnoDto
	{
		public Guid Id { get; set; }
		public IngestionMode ingestionMode { get; set; }
		public string SchedduleTime { get; set; }
		public ChannelPreference channelPreference{get; set;}
		public Content content { get; set; }

    }

	public class IngestionMode
	{
		public bool isBestEfford { get; set; }
		public bool isScheddule { get; set; }
		
    }
	public class ChannelPreference
    {
        public bool isTherePreference { get; set; }
		public IEnumerable<string> ChannelList { get; set; }

    }
	public class Content
	{
		public bool isAudiovisual { get; set; }
		public bool hasPreference { get; set; }
		public string preferedResolution { get; set; }
    }
	
}

