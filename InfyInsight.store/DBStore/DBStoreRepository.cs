using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InfyInsight.store.DBStore
{
    public class DBStoreRepository:IStoreRepository
    {
        private DBStoreEntities _dbContext;
        public DBStoreRepository()
        {
            _dbContext = new DBStoreEntities();
        }

        public DBStoreRepository(DBStoreEntities dbEntities)
        {
            _dbContext = dbEntities;
        }

        public Guid AddProduct(models.Product product)
        {
            var id = Guid.NewGuid();
            product.ProductId = id;
            var data = this.SerializeJson<models.Product>(product);
            _dbContext.Products.Add(new Product
            {
                Id = id,
                Product1 = data
            });
            _dbContext.SaveChanges();
            return id;
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

        private string SerializeJson<T>(T source)
        {
            var seralizedData = JsonConvert.SerializeObject(source);
            return seralizedData;
        }

        private T DeSerializeJson<T>(string source)
        {
            var deseralizedData = JsonConvert.DeserializeObject<T>(source);
            return deseralizedData;
        }
    }
}
