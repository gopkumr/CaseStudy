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

        [HttpPost]
        [Route("api/products")]
        public Guid AddProduct([FromBody]Product value)
        {
            return _productManager.AddProduct(value);
        }

        [HttpPatch]
        [Route("api/products")]
        public Product AddProductInventory([FromBody]Product value)
        {
            return _productManager.AddInventory(value);
        }
    }
}
