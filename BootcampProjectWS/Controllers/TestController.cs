using BootcampProjectWS.Filters;
using LibraryMethod.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BootcampProjectWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        //[ServiceFilter<SessionUserFilter>] //esta línea también me funcionó
        [ServiceFilter(typeof(SessionUserFilter))]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("En metodo get");
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            var SectionKey = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("tokenSession");
            EncryptHelper encryptH = new EncryptHelper
            {
                EncKey = SectionKey.GetValue<string>("key"),
                EncMackKey = SectionKey.GetValue<string>("macKey")
            };

            return encryptH.EncryptValue(value);
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
