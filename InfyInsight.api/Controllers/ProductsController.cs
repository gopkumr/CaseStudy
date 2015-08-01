using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfyInsight.business.contract;
using InfyInsight.models;

namespace InfyInsight.api.Controllers
{
    public class ProductsController : Controller
    {
        private IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        [Route("/products/{searchstring}")]
        public IEnumerable<Product> GetProducts(string searchstring)
        {
           var products=new List<Product>();
            return products;
        }
    }
}
