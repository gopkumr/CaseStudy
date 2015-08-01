using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.models;

namespace InfyInsight.business.contract
{
    public interface IOrderManager
    {
        Order AddProductToCart(Guid orderId, Guid productId, int quantity);
        Order RemoveProductToCart(Guid orderId, Guid productId, int quantity);
        bool CheckoutCart(Guid orderId);
        Guid CreateCart();
    }
}
