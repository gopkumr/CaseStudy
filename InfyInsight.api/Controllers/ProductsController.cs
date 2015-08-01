using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using InfyInsight.business.contract;
using InfyInsight.models;

namespace InfyInsight.api.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [Route("api/products/{searchstring}")]
        public IHttpActionResult GetProducts(string searchstring="")
        {
            return Ok(_productManager.SearchProducts(searchstring));
        }

        [HttpGet]
        [Route("api/products/{id:Guid}")]
        public IHttpActionResult GetProducts(Guid id)
        {
            return Ok(_productManager.SearchProducts(id));
        }
    }
}
