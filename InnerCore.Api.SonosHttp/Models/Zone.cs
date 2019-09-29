using Newtonsoft.Json;
using System.Collections.Generic;

namespace InnerCore.Api.SonosHttp.Models
{
	public class Zone
	{
		[JsonProperty("uuid")]
		public string Uuid { get; set; }

		[JsonProperty("coordinator")]
		public ZoneMember Coordinator { get; set; }

		[JsonProperty("members")]
		public List<ZoneMember> Members { get; set; }
	}
}
