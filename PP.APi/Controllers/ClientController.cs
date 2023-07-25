using Microsoft.AspNetCore.Mvc;
using PP.APi.Database;
using PP.Library.Models;

namespace PP.APi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetClient")]
        public List<Client> Get()
        {
            return ClientDatabase.clients;
        }

        [HttpGet("GetClient/{id}")]
        public Client GetID(int id) 
        {
            if (id < 0 || id > ClientDatabase.clients.Count)
                return new Client();
            return ClientDatabase.clients[id];
        }
    }


}
