using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalRServer.Hubs
{
    public class ManagerHub
    {
        //private readonly IHubContext<NotificationHub> _hubContext;

        //public ManagerHub(IHubContext<NotificationHub> hubContext)
        //{
        //    _hubContext = hubContext;
        //}


        public List<UserHub> Users { get; private set; } = new List<UserHub>();

        public void ConnectUser(string userName, string connectionId)
        {
            var userExists = GetConnectedUserByName(userName);
            if (userExists != null)
            {
                userExists.AddConnection(connectionId);
                return;
            }

            var user = new UserHub(userName);
            user.AddConnection(connectionId);
            Users.Add(user);

            //_hubContext


        }

        public bool DisconnectUser(string connectionId)
        {
            var userExists = GetConnectedUserById(connectionId);

            if (userExists == null) return false;

            if (!userExists.ConnectionsHub.Any()) return false; 
            

            var connectionExists = userExists.ConnectionsHub.Select(x => x.ConnectionId).First().Equals(connectionId);
            

            if (!connectionExists) return false; 

            if (userExists.ConnectionsHub.Count() == 1)
            {
                Users.Remove(userExists);
                return true;
            }

            userExists.DeleteConnection(connectionId);
            return false;
        }

        private UserHub GetConnectedUserById(string connectionId) =>
            Users
                .FirstOrDefault(x => x.ConnectionsHub.Select(c => c.ConnectionId)
                .Contains(connectionId));

        private UserHub GetConnectedUserByName(string userName) =>
            Users
                .FirstOrDefault(x => string.Equals(
                    x.UserName,
                    userName,
                    StringComparison.CurrentCultureIgnoreCase));
    }
}
