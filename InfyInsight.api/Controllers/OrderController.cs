using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InfyInsight.api.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/cart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/cart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/cart
        public void Post([FromBody]string value)
        {
        }

        // PUT api/cart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cart/5
        public void Delete(int id)
        {
        }
    }
}
