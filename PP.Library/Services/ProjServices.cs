using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Models;

namespace PP.Library.Services
{
    public class ProjServices
    {

        private List<Project> _projects = new List<Project>();

        public List<Project> Projects
        {
            get 
            {
                return _projects;
            }
        }

        public void Add (Project proj)
        {
            Projects.Add(proj);
        }

        /**********************CRUD FUNCTIONS**********************/

        static public void CreateProject(ref List<Project> projects,
            ref List<Client> clients)
        {
            Console.WriteLine("Which client does this project belong to?");
            int clientNum = ClientServices.SelectClient(ref clients);
            if (clientNum < 0)
                return;

            string shortName;

            Console.Write("Give this project a name: ");
            string name = Console.ReadLine() ?? string.Empty;

            if (name.Length > 10)
                shortName = name.Substring(0, 10) + "...";
            else shortName = name;

            projects.Add(new Project(projects.Capacity + 1, DateTime.Now,
                shortName, name, clientNum, clients[clientNum - 1]));

            Console.WriteLine("Project " + name + " added");
        } //end CreateProject

        static public void ViewProject(ref List<Project> projects)
        {
            int projNum = selectProject(ref projects) - 1;

            if (projNum < 0)
                return;

            printProjectInfo(projects[projNum]);
        } //end ViewProject

        static public void UpdateProject(ref List<Project> projects, ref List<Client> clients)
        {
            int projNum = selectProject(ref projects) - 1;
            if (projNum < 0)
                return;

            char confirm;
            DateTime newDT;
            Project proj = projects[projNum];

            Console.WriteLine("Update project: " + proj.LongName + "?\n" +
                "Please type 'y' for yes and 'n' for no");
            char.TryParse(Console.ReadLine(), out confirm);

            if (confirm == 'n')
                return;

            for (; ; )
            {
                int choice;
                Console.WriteLine("What would you like to edit? \n1) Project" +
                    " name \n2) Open Date \n3) Close Date\n 4) Active status" +
                    "\n5) Client \n0) Quit");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Presenting new project info");
                        printProjectInfo(proj, true);
                        return;
                    case 1:
                        Console.Write("Please enter new name?");
                        proj.LongName = Console.ReadLine() ?? string.Empty; //?? => null coalescence operator, if thing on left null, use thing on right
                        if (proj.LongName.Length > 10)
                            proj.ShortName = proj.LongName.Substring(0, 10) + "...";
                        else proj.ShortName = proj.LongName;
                        break;
                    case 2:
                        Console.Write("Please enter a new date: ");
                        DateTime.TryParse(Console.ReadLine(), out newDT);
                        proj.OpenDate = newDT;
                        break;
                    case 3:
                        Console.Write("Please enter a new date: ");
                        DateTime.TryParse(Console.ReadLine(), out newDT);
                        proj.CloseDate = newDT;
                        break;
                    case 4:
                        proj.Closed = !proj.Closed;
                        break;
                    case 5:
                        int newClient = ClientServices.SelectClient(ref clients) - 1;
                        if (newClient < 0)
                            continue;
                        else
                        {
                            proj.ClientID = newClient;
                            proj.Owner = clients[newClient];
                        }
                        break;
                    default:
                        Console.WriteLine("IDK what you mean big dog");
                        break;
                } //end switch
                Console.Clear();
            } //end for
        }   //end UpdateProject

        static public bool DeleteProject(ref List<Project> projects)
        {
            int projNum = selectProject(ref projects) - 1;
            if (projNum < 0)
                return false;

            Project proj = projects[projNum];
            char confirm;

            Console.WriteLine("Delete project " + proj.LongName + "?\n"
                + "Please press 'y' for yes or 'n' for no");
            char.TryParse(Console.ReadLine(), out confirm);

            if (confirm == 'n')
                return false;

            projects.Remove(proj);
            return true;
        } //end DeleteProject

        /**********************HELPER FUNCTIONS**********************/
        static private void printProjectInfo(Project p, bool edit = false)
        {
            if (!p.Closed)
                Console.WriteLine("Name: " + p.LongName + "\nClient's ID: " +
                    p.ClientID + "\nOpened:" + p.OpenDate + "\nClosed Date: " +
                    p.CloseDate + '\n');
            else
            {
                Console.WriteLine("Name: " + p.LongName + "\nClient's ID: " +
                    p.ClientID + "\nOpened:" + p.OpenDate + "\nClosed Date: " +
                    "Project is still in progress" + '\n');
            }

            if (edit)
            {
                Console.WriteLine("Closed: " + p.Closed.ToString() + '\n');
            }
        } // end printProjectInfo

        static private int selectProject(ref List<Project> projects)
        {
            if (projects.Count() == 0)
            {
                Console.WriteLine("You do not have any projects :(");
                return -1;
            }

            int option = 0;

            Console.WriteLine("Which project would you like to select");

            foreach (Project p in projects)
                Console.WriteLine(++option + ") " + p.ShortName);

            int.TryParse(Console.ReadLine(), out option);

            return option;
        } //end selectProject
    }
}
