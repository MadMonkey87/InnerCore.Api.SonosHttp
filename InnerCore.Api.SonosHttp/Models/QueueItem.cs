using Newtonsoft.Json;

namespace InnerCore.Api.SonosHttp.Models
{
	public class QueueItem
	{
		[JsonProperty("albumArtURI")]
		public string AlbumArtURI { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("artist")]
		public string Artist { get; set; }

		[JsonProperty("album")]
		public string Album { get; set; }
	}
}
