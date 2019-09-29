using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace InnerCore.Api.SonosHttp.Models
{
	public class Track
	{
		[JsonProperty("artist")]
		public string Artist { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("album")]
		public string Album { get; set; }

		[JsonProperty("duration")]
		public int Duration { get; set; }
	}

	public class CurrentTrack : Track
	{
		[JsonProperty("albumArtUri")]
		public string AlbumArtUri { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }

		[JsonProperty("trackUri")]
		public string TrackUri { get; set; }

		[JsonProperty("stationName")]
		public string StationName { get; set; }

		[JsonProperty("type")]
		public TrackType Type { get;set;}

		[JsonProperty("absoluteAlbumArtUri")]
		public string AbsoluteAlbumArtUri { get; set; }
	}

	public enum TrackType
	{
        [EnumMember(Value = "track")]
        Track,

        [EnumMember(Value = "radio")]
        Radio
    }
}
