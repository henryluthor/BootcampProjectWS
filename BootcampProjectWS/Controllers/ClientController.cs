using BootcampProjectWS.DBModels;
using BootcampProjectWS.Models;
using BootcampProjectWS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BootcampProjectWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly BootcampprojectContext _context;

        public ClientController(BootcampprojectContext context)
        {
            _context = context;
        }


        // GET: api/<ClientController>
        [HttpGet]
        //public IEnumerable<string> Get()
        public async Task<List<Client>> Get()
        {
            //return new string[] { "value1", "value2" };
            return await _context.Clients.ToListAsync();
        }


        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        public async Task<Client> Get(int id)
        {
            //return "value";
            return await _context.Clients.Where(client => client.Clientid == id).SingleAsync();
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] InsertClientModelRequest Model)
        {
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.InsertClient(_context, Model);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] InsertClientModelRequest Model)
        {
            bool updateResponse;
            ClientRepository clientRepository = new ClientRepository();
            updateResponse = clientRepository.UpdateClient(_context, Model, id);

            return updateResponse;
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
