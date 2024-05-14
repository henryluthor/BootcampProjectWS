using BootcampProjectWS.Bll;
using BootcampProjectWS.DBModels;
using BootcampProjectWS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BootcampProjectWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        BootcampprojectContext ContextDB;
        LoginBll LoginB;

        public LoginController(BootcampprojectContext context)
        {
            ContextDB = context;
            LoginB = new LoginBll(context);
        }


        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public GenericResponse<LoginResponseModel> Post([FromBody] LoginRequestModel model)
        {
            return LoginB.GetLoginUSer(model);
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
