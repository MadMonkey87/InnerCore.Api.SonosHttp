using System;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace InnerCore.Api.SonosHttp.Sample
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
            Console.WriteLine("you'll need a running instance of https://github.com/jishi/node-sonos-http-api");

            Console.Write("please enter the ip address:");
            var ip = Console.ReadLine();

            Console.WriteLine("please enter the port:");
            var port = 5005;
            while (!int.TryParse(Console.ReadLine(), out port)){
                Console.WriteLine("invalid number, please enter the port:");
            }

			var client = new SonosClient(ip, port);

			var zones = await client.GetAllZones();

            Console.WriteLine("the following rooms have been found:");
            foreach (var roomName in zones.SelectMany(z => z.Members.Select(m => m.RoomName)))
			{
				Console.WriteLine($" - {roomName}");
			}

            var roomToChange = zones.FirstOrDefault()?.Members.FirstOrDefault()?.RoomName;

            if (!string.IsNullOrEmpty(roomToChange))
            {
                Console.WriteLine($"lowering volume by 10% on {roomToChange}");
                await client.SetRelativeVolume(roomToChange, -10);

                Thread.Sleep(5000);

                Console.WriteLine($"increasing volume by 10% on {roomToChange}");
                await client.SetRelativeVolume(roomToChange, 10);

                Thread.Sleep(5000);

                Console.WriteLine($"pause on {roomToChange}");
                await client.Pause(roomToChange);

                Thread.Sleep(5000);

                Console.WriteLine($"resume on {roomToChange}");
                await client.Resume(roomToChange);
            }


            Console.Write("press enter to quit");
            Console.ReadLine();
        }
	}
}
