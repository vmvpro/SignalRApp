using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientSignalR
{
	class Program
	{
		static HubConnection hubConnection;

		static async Task Main(string[] args)
		{
			hubConnection = new HubConnectionBuilder()
				.WithUrl("http://localhost:55001/notification")
				.Build();

			hubConnection.On<string>("Send", message => Console.WriteLine($"Message: {message}"));

			await hubConnection.StartAsync();


			//hubConnection.ConnectionId

			bool isExit = false;

			while (!isExit)
			{
				var message = Console.ReadLine();

				if (message != "exit")
				{
					await hubConnection.SendAsync("SendMessage", message);
				}
				else
				{
					isExit = true;
				}

			}

			Console.ReadLine();
		}
	}
}
