using PP.APi.Database;
using PP.Library.Models;

namespace PP.APi.EC
{
    public class ClientEC
    {
        public Client Edit (Client client)
        {
            var clientToEdit 
                = Filebase.Current.Clients[client.Id];

            if(clientToEdit != null)
            {
                Filebase.Current.Clients.Remove(clientToEdit);
            }
            Filebase.Current.AddOrUpdate(client);
            return client;
        }

        public Client Add (Client client) 
        {
            client.Id = Filebase.NextId;
            Filebase.Current.AddOrUpdate(client);
            return client;
        }

        public Client Delete(int id)
        {
            if (id < 0 || id > Filebase.Current.Clients.Count)
                return new Client();
            var ClientToDelete = Filebase.Current.Clients[id];
            Filebase.Current.Delete(id.ToString());
            return ClientToDelete;
        }

        public Client GetByID(int id)
        {
            if (id < 0 || id > Filebase.Current.Clients.Count)
                return new Client();
            return Filebase.Current.Clients[id];
        }
    }
}

