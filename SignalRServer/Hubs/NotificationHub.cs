using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs
{
	public class NotificationHub : Hub //<ICommunicationHub>
	{
        private ManagerHub _managerHub;

        public NotificationHub(ManagerHub managerHub)
        {
            _managerHub = managerHub;
        }

        public override Task OnConnectedAsync()
		{
			Console.WriteLine("--> Connection Opened: " + Context.ConnectionId);
			
			return base.OnConnectedAsync();
		}

		public async Task RegisterUser(string name)
		{
			var userHub = new UserHub(name);
			userHub.AddConnection(Context.ConnectionId);
			_managerHub.Users.Add(userHub);

			//await Clients.Client(Context.ConnectionId).RegisterUser(name);

			await Clients.Client(Context.ConnectionId)
				.SendAsync("GetConnectionId", Context.ConnectionId);

			// Call the broadcastMessage method to update clients.
			await Clients.Client(Context.ConnectionId).SendAsync("RegisterUser", name);
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{
			Console.WriteLine("--> Connection Closed: " + Context.ConnectionId);
			return base.OnDisconnectedAsync(exception);
		}

		//public async Task Send(string name, string message)
		//{
		//	// Call the broadcastMessage method to update clients.
		//	//await Clients.All.SendAsync("broadcastMessage", name, message);
		//}

		//public async Task SendMessage(string message)
		//{
		//	//await Clients.Others.SendAsync("Send", message);
		//}

		//public Task SendMessageUser(string userName, string message)
		//{
		//	var concatString = $"{userName}: {message}";
		//	//return Clients.Others.SendAsync("Send", concatString);
		//}
	}
}
