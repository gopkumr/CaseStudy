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
    public class OrderController : ApiController
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpPatch]
        [Route("api/orders/{orderId:Guid}")]
        public Order AddProductToCart(Guid orderId, Guid productId, int quantity)
        {
            return _orderManager.AddProductToCart(orderId, productId, quantity);
        }

        [HttpDelete]
        [Route("api/orders/{orderId:Guid}")]
        public Order RemoveProductToCart(Guid orderId, Guid productId, int quantity)
        {
            return _orderManager.RemoveProductToCart(orderId, productId, quantity);
        }

        [HttpPost]
        [Route("api/orders/{orderId:Guid}")]
        public bool CheckoutCart(Guid orderId)
        {
            return _orderManager.CheckoutCart(orderId);
        }

        [HttpGet]
        [Route("api/orders")]
        public Guid CreateCart()
        {
            return _orderManager.CreateCart();
        }
    }
}
