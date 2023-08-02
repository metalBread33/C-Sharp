using Newtonsoft.Json;
using PP.APi.EC;
using PP.Library.Models;



namespace PP.APi.Database
{
    public class Filebase
    {
        private string _root;
        private string _clientRoot;
        private string _projectRoot;
        private static Filebase? _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = "C:\\Users\\kfoug\\Desktop\\C#\\PP.APi";
            _clientRoot = $"{_root}\\Clients";
            _projectRoot = $"{_root}\\Projects";
        }

        public Client AddOrUpdate(Client c)
        {
            //set up a new Id if one doesn't already exist
            if(c.Id <= 0)
            {
                c.Id = NextId;
            }

            string path = $"{_clientRoot}\\{c.Id}.json";

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(c));

            //return the item, which now has an id
            return c;
        }

        public List<Client> Clients
        {
            get
            {
                var root = new DirectoryInfo(_clientRoot);
                var _clients = new List<Client>();
                foreach (var clientFile in root.GetFiles())
                {
                    var client = JsonConvert
                        .DeserializeObject<Client>
                        (File.ReadAllText(clientFile.FullName));
                    _clients.Add(client ?? new Client());
                }
                return _clients;
            }
        }

       

        public bool Delete(string id)
        {
            string path = $"{_clientRoot}\\{id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }
            return true;
        }

        public static int NextId
        {
            get
            {
                return Current.Clients.Count;
            }
        }
    }


   
}
