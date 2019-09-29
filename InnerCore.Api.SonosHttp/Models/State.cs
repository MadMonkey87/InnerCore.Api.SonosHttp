using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace InnerCore.Api.SonosHttp.Models
{
	public class State
	{
		[JsonProperty("volume")]
		public int Volume { get;set;}

		[JsonProperty("mute")]
		public bool Mute { get;set;}

		[JsonProperty("equalizer")]
		public Equalizer Equalizer { get; set; }

		[JsonProperty("currentTrack")]
		public CurrentTrack CurrentTrack { get; set; }

		[JsonProperty("nextTrack")]
		public Track NextTrack { get; set; }

		[JsonProperty("trackNo")]
		public int TrackNumber { get; set; }

		[JsonProperty("elapsedTime")]
		public int elapsedTime { get; set; }

		[JsonProperty("playbackState")]
		public PlaybackState PlaybackState { get; set; }

		[JsonProperty("playmode")]
		public PlayMode PlayMode { get; set; }
	}

	public enum PlaybackState
	{
        [EnumMember(Value = "STOPPED")]
        Stopped,

        [EnumMember(Value = "PAUSED_PLAYBACK")]
		Paused,

        [EnumMember(Value = "PLAYING")]
        Playing,

        [EnumMember(Value = "TRANSITIONING")]
        Transitioning
    }
}
