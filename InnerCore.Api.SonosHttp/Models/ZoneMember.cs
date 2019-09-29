using Newtonsoft.Json;

namespace InnerCore.Api.SonosHttp.Models
{
	public class ZoneMember
	{
		[JsonProperty("uuid")]
		public string Uuid { get; set; }

		[JsonProperty("state")]
		public State State { get; set; }

		[JsonProperty("roomName")]
		public string RoomName { get; set; }

		[JsonProperty("coordinator")]
		public string Coordinator { get; set; }

		[JsonProperty("groupState")]
		public GroupState GroupState { get; set; }
	}
}
