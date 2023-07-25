using PP.APi.Database;
using PP.Library.Models;

namespace PP.APi.EC
{
    public class ClientEC
    {
        public Client Edit (Client client)
        {
            var clientToEdit 
                = ClientDatabase.clients[client.Id];

            if(clientToEdit != null)
            {
                ClientDatabase.clients.Remove(clientToEdit);
            }
            ClientDatabase.clients.Add(client);
            return client;
        }

        public Client Add (Client client) 
        {
            client.Id = ClientDatabase.NextId;
            ClientDatabase.clients.Add(client);
            return client;
        }

        public Client Delete(int id)
        {
            if (id < 0 || id > ClientDatabase.clients.Count)
                return new Client();
            var ClientToDelete = ClientDatabase.clients[id];
            ClientDatabase.clients.RemoveAt(id);
            return ClientToDelete;
        }

        public Client GetByID(int id)
        {
            if (id < 0 || id > ClientDatabase.clients.Count)
                return new Client();
            return ClientDatabase.clients[id];
        }
    }
}

