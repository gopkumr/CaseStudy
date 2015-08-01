using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InfyInsight.business.contract;
using InfyInsight.models;

namespace InfyInsight.api.Controllers
{
    public class AdminController : ApiController
    {
        private IProductManager _productManager;
        public AdminController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("api/products")]
        public Guid AddProduct([FromBody]Product value)
        {
            return _productManager.AddProduct(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
