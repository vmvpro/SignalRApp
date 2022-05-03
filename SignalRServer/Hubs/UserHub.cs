using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalRServer.Hubs
{
    public class UserHub
    {
        private List<ConnectionHub> _connections;

        public UserHub(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            _connections = new List<ConnectionHub>();
        }

        public string UserName { get;}  
        public IEnumerable<ConnectionHub> ConnectionsHub { get => _connections; }
        
        public void AddConnection(string connectionId)
        {
            if (connectionId == null)
            {
                throw new ArgumentNullException(nameof(connectionId));
            }

            var connection = new ConnectionHub
            {
                ConnectionId = connectionId
            };

            _connections.Add(connection);
        }

        public void DeleteConnection(string connectionId)
        {
            if (connectionId == null)
            {
                throw new ArgumentNullException(nameof(connectionId));
            }

            var connection = _connections.SingleOrDefault(x => x.ConnectionId.Equals(connectionId));
            if (connection == null)
            {
                return;
            }
            _connections.Remove(connection);
        }



    }
}
