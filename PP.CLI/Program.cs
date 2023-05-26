using System;
using PP.Library.Services;
using PP.Library.Models;


namespace PP.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuSelection;
            List<Client> clients = new List<Client>();
            List<Project> projects = new List<Project>();

            Console.WriteLine("Welcome to [insert app name]");

            menuSelection = Menu();
            while (menuSelection != 0)
            {
                switch (menuSelection)
                {
                    case 1:
                        ClientServices.CreateClient(ref clients);
                        break;
                    case 2:
                        ClientServices.ViewClient(ref clients);
                        break;
                    case 3:
                        ClientServices.UpdateClient(ref clients);
                        break;
                    case 4:
                        ClientServices.DeleteClient(ref clients);
                        break;
                    case 5:
                        ProjServices.CreateProject(ref projects, ref clients);
                        break;
                    case 6:
                        ProjServices.ViewProject(ref projects);
                        break;
                    case 7:
                        ProjServices.UpdateProject(ref projects, ref clients);
                        break;
                    case 8:
                        ProjServices.DeleteProject(ref projects);
                        break;
                } //end switch

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                menuSelection = Menu();

            }//end while loop

            Console.WriteLine("Goodbye!");

        }//end main

        static int Menu()
        {
            bool valid = false;
            int menuSelction;
            while (!valid)
            {
                Console.WriteLine("What would you like to do?" +
                "\n1) Create new client \n2) View client info" +
                "\n3) Update client info \n4) Delete client" +
                "\n5) Create new project \n6) View project info" +
                "\n7) Update project info \n8) Delete project" +
                "\n0) Quit");

                if (int.TryParse(Console.ReadLine(), out menuSelction))
                {
                    if (menuSelction >= 0 && menuSelction <= 8)
                        return menuSelction;

                    else Console.WriteLine("IDK what you mean big dog.");
                }
                else Console.WriteLine("IDK what you mean big dog.");

            }

            return 0;
        }
    }
}