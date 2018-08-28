using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smart_Accounting.Application.Customers.Interfaces;

namespace Smart_Accounting.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly ICustomerQuery _customerQ;
        public ValuesController(ICustomerQuery customer) {
            _customerQ = customer;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var x = _customerQ.GetAll();
            return Ok(x);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
