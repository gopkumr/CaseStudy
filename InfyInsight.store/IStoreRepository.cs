using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.models;

namespace InfyInsight.store
{
    public interface IStoreRepository
    {
        Guid AddProduct(Product product);
        Product AddInventory(Guid productId, int quantity );
        Product GetProduct(Guid id);
        Product GetProduct(Product product);
        IEnumerable<Product> SearchProduct(string WildCardString);

        User LoginUser(string userName, string password);
        User RegisterUser(User user, string password);

        Order AddProductToCart(Guid orderId, Guid productId, int quantity);
        Order RemoveProductToCart(Guid orderId, Guid productId, int quantity);
        bool CheckoutCart(Guid orderId);
    }
}
