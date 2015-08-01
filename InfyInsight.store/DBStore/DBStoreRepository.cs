using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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
            var product = _dbContext.Products.FirstOrDefault(q => q.Id == productId);
            if (product != null)
            {
                var productData=this.DeSerializeJson<models.Product>(product.Product1);
                productData.Inventory += quantity;
                var data = this.SerializeJson<models.Product>(productData);
                product.Product1 = data;
                _dbContext.SaveChanges();
            }

            throw new ObjectNotFoundException(string.Format("Product with id {0} not found", productId));
        }

        public models.Product GetProduct(Guid id)
        {
            var product = _dbContext.Products.FirstOrDefault(q => q.Id == id);
            if (product != null)
            {
                var productData = this.DeSerializeJson<models.Product>(product.Product1);
                return productData;
            }

            throw new ObjectNotFoundException(string.Format("Product with id {0} not found", id));
        }

        public models.Product GetProduct(models.Product product)
        {
            var dbProductDb = _dbContext.Products.FirstOrDefault(q => q.Id == product.ProductId);
            if (dbProductDb != null)
            {
                var productData = this.DeSerializeJson<models.Product>(dbProductDb.Product1);
                return productData;
            }

            throw new ObjectNotFoundException(string.Format("Product with id {0} not found", product.ProductId));
        }

        public IEnumerable<models.Product> SearchProduct(string WildCardString)
        {
            var dbProductDb = _dbContext.Products
                        .ToList()
                        .Where(q => this.DeSerializeJson<models.Product>(q.Product1).LongDescription.Contains(WildCardString) || this.DeSerializeJson<models.Product>(q.Product1).ShortDescription.Contains(WildCardString));
            if (dbProductDb.Any())
            {
                return dbProductDb.Select(q => this.DeSerializeJson<models.Product>(q.Product1)).ToList();
            }
            return new List<models.Product>();
        }

        public models.User LoginUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public models.User RegisterUser(models.User user)
        {
            throw new NotImplementedException();
        }

        public models.Order AddProductToCart(Guid orderId, Guid productId, int quantity)
        {
            var order = new Order();
            if (orderId != Guid.Empty)
            {
                order = _dbContext.Orders.FirstOrDefault(q => q.Id == orderId);
            }

            if (order != null)
            {
                var orderModel = this.DeSerializeJson<models.Order>(order.Order1);
                var productExisting = orderModel.Items.Where(q => q.Key.ProductId == productId).ToList();
                if (productExisting.Any())
                {
                    var itemExisting = productExisting.First();
                    orderModel.Items.Remove(itemExisting.Key);
                    orderModel.Items.Add(itemExisting.Key, itemExisting.Value + quantity);
                }
                else
                {
                    var newProduct = _dbContext.Products.FirstOrDefault(q => q.Id == productId);
                    if (newProduct != null)
                    {
                        var newProductModel = this.DeSerializeJson<models.Product>(newProduct.Product1);
                        orderModel.Items.Add(newProductModel, quantity);
                    }
                }
                var orderData = this.SerializeJson(orderModel);
                order.Order1 = orderData;
                if (order.Id == Guid.Empty)
                {
                    order.Id = Guid.NewGuid();
                    orderModel.OrderId = order.Id;
                    _dbContext.Orders.Add(order);
                }
                _dbContext.SaveChanges();
                return orderModel;
            }
            return null;
        }

        public models.Order RemoveProductToCart(Guid orderId, Guid productId, int quantity)
        {
            var order = _dbContext.Orders.FirstOrDefault(q => q.Id == orderId);
            if (order != null)
            {
                var orderModel = this.DeSerializeJson<models.Order>(order.Order1);
                var productExisting = orderModel.Items.Where(q => q.Key.ProductId == productId).ToList();
                if (productExisting.Any())
                {
                    var itemExisting = productExisting.First();
                    orderModel.Items.Remove(itemExisting.Key);
                    if (itemExisting.Value > quantity)
                    {
                        orderModel.Items.Add(itemExisting.Key, itemExisting.Value - quantity);
                    }
                }

                var orderData = this.SerializeJson(orderModel);
                order.Order1 = orderData;
                _dbContext.SaveChanges();
                return orderModel;
            }
            return null;
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
