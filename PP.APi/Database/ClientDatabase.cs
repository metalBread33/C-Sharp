﻿using PP.Library.Services;
using PP.Library.Models;
namespace PP.APi.Database
{
    public static class ClientDatabase
    {
        //public static List<Client> clients = ClientServices.Current.Clients;
        public static List<Client> clients = new List<Client>
        {
            new Client{Id = 0, Name = "John", Closed = false, Notes="N/A"},
            new Client{Id = 1, Name = "Johnathan", Closed = false, Notes="N/A"},
            new Client{Id = 2, Name = "Jon", Closed = false, Notes="N/A"},
        };

        public static int NextId
        {
            get
            {
                return clients.Count;
            }
        }
    }
}
