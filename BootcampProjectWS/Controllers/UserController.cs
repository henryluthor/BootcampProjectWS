using BootcampProjectWS.Bll;
using BootcampProjectWS.DBModels;
using BootcampProjectWS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BootcampProjectWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserBll UserB;
        private readonly BootcampprojectContext _Context;

        public UserController(BootcampprojectContext context)
        {
            _Context = context;
            UserB = new UserBll(context);
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public GenericResponse<bool> Post([FromBody] InsertUserModelRequest model)
        {
            return UserB.InsertUser(model);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
