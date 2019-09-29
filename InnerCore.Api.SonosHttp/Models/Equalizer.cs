using Newtonsoft.Json;

namespace InnerCore.Api.SonosHttp.Models
{
	public class Equalizer
	{
		[JsonProperty("bass")]
		public int Bass { get; set; }

		[JsonProperty("treble")]
		public int Treble { get; set; }

		[JsonProperty("loudness")]
		public bool Loudness { get; set; }
	}
}
