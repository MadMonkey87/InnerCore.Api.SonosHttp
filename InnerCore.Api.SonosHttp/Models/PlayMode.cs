using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace InnerCore.Api.SonosHttp.Models
{
	public class PlayMode
	{
		[JsonProperty("repeat")]
		public RepeatType Repeat { get; set; }

		[JsonProperty("shuffle")]
		public bool Shuffle { get; set; }

		[JsonProperty("crossfade")]
		public bool Crossfade { get; set; }
	}

	public enum RepeatType
	{
        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "one")]
        One
    }
}
