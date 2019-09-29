using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace InnerCore.Api.SonosHttp.Models
{
	public class Response
	{
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; } = ResponseStatus.Error;

        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("Stack")]
        public string Stack { get; set; }
    }

	public enum ResponseStatus
	{
		[EnumMember(Value = "success")]
		Success,

		[EnumMember(Value = "error")]
		Error
	}
}
