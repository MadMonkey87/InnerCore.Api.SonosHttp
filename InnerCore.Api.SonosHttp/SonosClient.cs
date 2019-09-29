using InnerCore.Api.SonosHttp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InnerCore.Api.SonosHttp
{
	public class SonosClient
	{
		private HttpClient _client = new HttpClient() { Timeout = TimeSpan.FromSeconds(Constants.TIMEOUT_IN_SECONDS) };

		private readonly string _ip;

		private readonly int _port;

		public string ApiBase
		{
			get
			{
				return string.Format("http://{0}:{1}/", _ip, _port);
			}
		}

		public SonosClient(string ip, int port = 5005)
		{
            _ip = ip ?? throw new ArgumentNullException(nameof(ip));
			_port = port;
		}

		public async Task<List<Zone>> GetAllZones()
		{
            // todo: GetStringAsync throws already an exception if we get an 500er response. 

			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}zones", ApiBase))).ConfigureAwait(false);
			return DeserializeResult<List<Zone>>(stringResult);
		}

		public async Task LockVolumes()
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}lockvolumes", ApiBase))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task UnlockVolumes()
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}unlockvolumes", ApiBase))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task PauseAll(TimeSpan? timeout = null)
		{
			var url = timeout.HasValue ? new Uri(string.Format("{0}pauseall/{1}", ApiBase, timeout?.TotalMinutes)) : new Uri(string.Format("{0}pauseall", ApiBase));
			var stringResult = await _client.GetStringAsync(url).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task ResumeAll(TimeSpan? timeout = null)
		{
			var url = timeout.HasValue ? new Uri(string.Format("{0}resumeall/{1}", ApiBase, timeout?.TotalMinutes)) : new Uri(string.Format("{0}resumeall", ApiBase));
			var stringResult = await _client.GetStringAsync(url).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task ReIndex()
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}reindex", ApiBase))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task SleepAll(TimeSpan? timeout = null)
		{
			var url = timeout.HasValue? new Uri(string.Format("{0}sleep/{1}", ApiBase, timeout?.TotalMinutes)) : new Uri(string.Format("{0}sleep", ApiBase));
			var stringResult = await _client.GetStringAsync(url).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task<State> GetState(string zone)
		{
            var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/state", ApiBase, zone))).ConfigureAwait(false);
			return DeserializeResult<State>(stringResult);
		}

		public async Task Resume(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/play", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task Pause(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/pause", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task TogglePlayPause(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/playpause", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

        // todo: seems broken at http api itself
		public async Task SeekTrack(string zone, TimeSpan position)
		{
            var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/trackseek/{2}", ApiBase, zone, Math.Round(position.TotalSeconds)))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task NextTrack(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/next", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task PreviousTrack(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/previous", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task SetAbsoluteVolume(string zone, int volume)
		{
            volume = Helper.Clamp(volume, 0, 100);

            var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/volume/{2}", ApiBase, zone, volume))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task SetRelativeVolume(string zone, int volume)
		{
            volume = Helper.Clamp(volume, -100, 100);

            var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/volume/{2}{3}", ApiBase, zone, volume < 0 ? "" : "+", volume))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task SetAbsoluteGroupVolume(string zone, int volume)
		{
            volume = Helper.Clamp(volume, 0, 100);

            var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/groupvolume/{2}", ApiBase, zone, volume))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task SetRelativeGroupVolume(string zone, int volume)
		{
            volume = Helper.Clamp(volume, -100, 100);

            var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/groupvolume/{2}{3}", ApiBase, zone, volume < 0 ? "" : "+", volume))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task Mute(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/mute", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task Unmute(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/unmute", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task MuteGroup(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/groupmute", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task UnmuteGroup(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/groupunmute", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task ToggleMute(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/togglemute", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task LockVolume(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/lockvolumes", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task UnlockVolume(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/unlockvolumes", ApiBase, zone))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task Repeat(string zone, RepeatType repeat)
		{
            var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/repeat/{2}", ApiBase, zone, Helper.GetEnumMemberValue(repeat)))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task Shuffle(string zone, bool shuffle)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/shuffle/{2}", ApiBase, zone, shuffle ? "true" : "false"))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task Crossfade(string zone, bool crossfade)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/crossfade/{2}", ApiBase, zone, crossfade ? "true" : "false"))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task AddToGroup(string zone, string zoneToAdd)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/add/{2}", ApiBase, zone, zoneToAdd))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task RemoveFromGroup(string zone, string zoneToRemove)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/remove/{2}", ApiBase, zone, zoneToRemove))).ConfigureAwait(false);
			DeserializeResult<Response>(stringResult);
		}

		public async Task Isolate(string zone)
		{
			var stringResult = await _client.GetStringAsync(new Uri(string.Format("{0}{1}/isolate", ApiBase, zone))).ConfigureAwait(false);
            DeserializeResult<Response>(stringResult);
		}

		private static T DeserializeResult<T>(string json) where T : class
		{
			try
			{
				var objectResult = JsonConvert.DeserializeObject<T>(json);

				return objectResult;
			}
			catch (Exception)
            {
                var defaultResult = DeserializeDefaultResponse(json);

                if (defaultResult.Status == ResponseStatus.Error)
                    throw new CommandFailedException(defaultResult.Error);
            }
			return null;
		}

        protected static Response DeserializeDefaultResponse(string json)
        {
            var result = new Response();

            try
            {
                result = JsonConvert.DeserializeObject<Response>(json);
            }
            catch (JsonSerializationException)
            {
                //Ignore JsonSerializationException
            }

            return result;
        }
    }
}
