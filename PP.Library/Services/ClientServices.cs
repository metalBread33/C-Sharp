﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using PP.Library.Models;
using PP.Library.Utilities;

namespace PP.Library.Services
{
    public class ClientServices
    {
        private static ClientServices? _instance;

        public static ClientServices Current
        {
            get
            {
                if (_instance == null)
                    _instance = new ClientServices();
                return _instance;
            }
        }

        private List<Client> clients = new List<Client>();

        public ClientServices()
        {
        }

        public List<Client> Clients 
        { 
            get 
            { 
                var response = new WebRequestHandler()
                    .Get("/Client")
                    .Result;
                var clients = JsonConvert.
                    DeserializeObject<List<Client>>(response);
                return clients ?? new List<Client>();
            }
        }

        public Client GetClientByID (int id)
        {
            var response = new WebRequestHandler()
                    .Get($"/{id}")
                    .Result;
            var client = JsonConvert.
                DeserializeObject<Client>  (response);
            return client; 
            //return clients[id];
        }

        public bool CanClose(Client c)
        {
            foreach (var proj in c.Projects)
                if (proj.Closed == false)
                    return false;
            return true;
        }

        /*For Maui APP
        /**********************CRUD FUNCTIONS**********************/
        public void Delete(Client client) 
        {
            int deleteThisClient = client.Id;
            var response = new WebRequestHandler().Delete($"/Delete/{deleteThisClient}").Result;
            //Clients.RemoveAt(deleteThisClient) ;
        }

        public void Add(Client client)
        {
            //Clients.Add(client);
            var response = new WebRequestHandler().Post("/Add", client).Result;
        }

        public void Add(Project project, Client client)
        {
            client.Projects.Add(project);
        }

        public void Edit (Client newInfo, Client editClient)
        {
            editClient.Name = newInfo.Name;
            editClient.Notes = newInfo.Notes;
            editClient.OpenDate = newInfo.OpenDate;
            editClient.CloseDate = newInfo.CloseDate;
            editClient.Closed = newInfo.Closed;

            var response = new WebRequestHandler().Post($"/Edit/{editClient.Id}", editClient).Result;
        }



        /**********************CRUD FUNCTIONS**********************/
        static public void CreateClient(ref List<Client> clients)
        {
            string name, notes;
            int id = clients.Count+1;

            Console.Write("Type client's name: ");
            name = Console.ReadLine() ?? "No name given";

            Console.Write("Notes on the client: ");
            notes = Console.ReadLine() ?? "None";

            clients.Add(new Client(id,DateTime.Today, name, notes));

            Console.WriteLine("Added client: " + name);
        } //end CreateClient

        static public void ViewClient(ref List<Client> clients)
        {
            int clientNum = SelectClient(ref clients) - 1;
            if (clientNum < 0)
                return;
            printClientInfo(clients[clientNum]);
        }// end ViewClient

        static public void UpdateClient(ref List<Client> clients)
        {
            int clientNum = SelectClient(ref clients) - 1;
            if (clientNum < 0)
                return;

            char confirm;
            DateTime newDT;
            Client client = clients[clientNum];

            Console.WriteLine("Update client " + client.Name + '?' +
                " (Please type 'y' for yes or 'n' for no)");
            char.TryParse(Console.ReadLine(), out confirm);

            if (confirm == 'n')
                return;
            printClientInfo(client, true);
            do
            {
                int choice;
                Console.WriteLine("What would you like to edit?\n1) Client name" +
                    "\n2) Open date\n3) Close date \n4) Active status" +
                    "\n5) Notes \n0) Quit");

                int.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    Console.Write("Please enter new name: ");
                    client.Name = Console.ReadLine() ?? client.Name;
                }

                if (choice == 2)
                {
                    Console.Write("Please enter new date: ");
                    DateTime.TryParse(Console.ReadLine(), out newDT);
                    client.OpenDate = newDT;
                }

                if (choice == 3)
                {
                    Console.Write("Please enter new date: ");
                    DateTime.TryParse(Console.ReadLine(), out newDT);
                    client.CloseDate = newDT;
                }

                if (choice == 4)
                    client.Closed = !client.Closed;

                if (choice == 5)
                    client.Notes = Console.ReadLine() ?? client.Notes;

                if (choice == 0)
                    return;

                Console.WriteLine("Presenting new information: ");
                printClientInfo(client, true);

            }
            while (true);
        }// end UpdateClient

        static public bool DeleteClient(ref List<Client> clients)
        {
            int clientNum = SelectClient(ref clients) - 1;

            if (clientNum < 0)
                return false;
            Client client = clients[clientNum];
            char confirm;

            Console.WriteLine("Delete client " + client.Name + "? \n(Type 'y' " +
                "for yes or 'n' for no).");
            char.TryParse(Console.ReadLine(), out confirm);

            if (confirm == 'n')
                return false;

            clients.Remove(client);
            return true;
        } //end DeleteClient

        /**********************HELPER FUNCTIONS**********************/
        static private void printClientInfo(Client c, bool edit = false)
        {
            if (!c.Closed)
                Console.WriteLine("Name: " + c.Name + "\nID: " + c.Id +
                    "\nOpened: " + c.OpenDate + "\nClosed: " + c.CloseDate +
                    "\nNotes: " + c.Notes );
            else
                Console.WriteLine("Name: " + c.Name + "\nID: " + c.Id +
                   "\nOpened: " + c.OpenDate + "\nClosed: Not closed yet " +
                   "\nNotes: " + c.Notes);
            if (edit)
                Console.WriteLine("Closed: " + (!c.Closed).ToString());

        }// end print info

        static public int SelectClient(ref List<Client> clients)
        {
            if (clients.Count == 0)
            {
                Console.WriteLine("You do not have any clients :(");
                return -1;
            }
            int option = 0;

            Console.WriteLine("Which client would you like to select?");

            foreach (Client client in clients)
                Console.WriteLine(++option + ") " + client.Name);

            int.TryParse(Console.ReadLine(), out option);

            return option;
        } //end select client

    }
}
