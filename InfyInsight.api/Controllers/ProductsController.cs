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
        public IEnumerable<Product> GetProducts(string searchstring)
        {
            return _productManager.SearchProducts(searchstring);
        }

        [HttpGet]
        [Route("api/products/{id:Guid}")]
        public Product GetProducts(Guid id)
        {
            return _productManager.SearchProducts(id);
        }
    }
}
