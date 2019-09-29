using Newtonsoft.Json;

namespace InnerCore.Api.SonosHttp.Models
{
	public class GroupState
	{
		[JsonProperty("volume")]
		public int Volume { get; set; }

		[JsonProperty("mute")]
		public bool Mute { get; set; }
	}
}
