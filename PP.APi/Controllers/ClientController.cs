using Microsoft.AspNetCore.Mvc;
using PP.APi.Database;
using PP.APi.EC;
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

        [HttpGet]
        public List<Client> Get()
        {
            return ClientDatabase.clients;
        }

        [HttpGet("/{id}")]
        public Client GetByID(int id) 
        {
           return new ClientEC().GetByID(id);
        }

        [HttpDelete("/Delete/{id}")]
        public Client Delete(int id)
        {
           return new ClientEC().Delete(id);
        }

        [HttpPost("/Edit/{id}")]
        public Client Edit([FromBody] Client client)
        {
            return new ClientEC().Edit(client);
        }


        [HttpPost("/Add")]
        public Client Add([FromBody] Client client)
        {
            return new ClientEC().Add(client);
        }

    }


}
