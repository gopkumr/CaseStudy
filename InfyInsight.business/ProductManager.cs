using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.business.contract;
using InfyInsight.store;

namespace InfyInsight.business
{
    public class ProductManager : IProductManager
    {
        private IStoreRepository _storeRepository;
        public ProductManager(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IEnumerable<InfyInsight.models.Product> SearchProducts(string wildCardString)
        {
            return _storeRepository.SearchProduct(wildCardString);
        }

        public InfyInsight.models.Product SearchProducts(Guid id)
        {
            return _storeRepository.GetProduct(id);
        }

        public Guid AddProduct(models.Product product)
        {
            return _storeRepository.AddProduct(product);
        }
    }
}
