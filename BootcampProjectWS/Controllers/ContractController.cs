using BootcampProjectWS.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BootcampProjectWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly BootcampprojectContext _context;

        public ContractController(BootcampprojectContext context)
        {
            _context = context;
        }


        // GET: api/<ContractController>
        [HttpGet]
        //public async IEnumerable<string> Get()
        public async Task<List<Contract>> Get()
        {
            //return new string[] { "value1", "value2" };
            return await _context.Contracts.ToListAsync();
        }

        // GET api/<ContractController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContractController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContractController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContractController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
