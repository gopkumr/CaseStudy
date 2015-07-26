using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfyInsight.store.DBStore
{
    public class DBStoreRepository:IStoreRepository
    {
        public Guid AddProduct(models.Product product)
        {
            throw new NotImplementedException();
        }

        public models.Product AddInventory(Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public models.Product GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public models.Product GetProduct(models.Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<models.Product> SearchProduct(string WildCardString)
        {
            throw new NotImplementedException();
        }

        public models.User LoginUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public models.User RegisterUser(models.User user)
        {
            throw new NotImplementedException();
        }

        public models.Order AddProductToCart(Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public models.Order RemoveProductToCart(Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public bool CheckoutCart(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
