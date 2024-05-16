using BootcampProjectWS.Filters;
using LibraryMethod.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //encryption post
        // POST api/<TestController>
        //[HttpPost]
        //public string Post([FromBody] string value)
        //{
        //    var SectionKey = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("tokenSession");
        //    EncryptHelper encryptH = new EncryptHelper
        //    {
        //        EncKey = SectionKey.GetValue<string>("key"),
        //        EncMackKey = SectionKey.GetValue<string>("macKey")
        //    };

        //    return encryptH.EncryptValue(value);
        //}


        //regex post
        [HttpPost]
        public bool Post([FromBody] string value)
        {
            //var SectionKey = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("tokenSession");
            //EncryptHelper encryptH = new EncryptHelper
            //{
            //    EncKey = SectionKey.GetValue<string>("key"),
            //    EncMackKey = SectionKey.GetValue<string>("macKey")
            //};

            //return encryptH.EncryptValue(value);

            //rule for username:
            //Minimum 8 characters, maximun 20 characters, can have lowercase o uppercase letters, and at least one number:
            string usernamePattern = @"^(?=.*\d)[a-zA-Z\d]{8,20}$";

            //rule for password:
            //Minimum 8 characters, maximun 30 characters, at least one uppercase letter, at least one lowercase letter and at least one number:
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,30}$";

            return Regex.IsMatch(value, usernamePattern);
            
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
