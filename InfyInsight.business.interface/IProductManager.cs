using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.models;

namespace InfyInsight.business.contract
{
    public interface IProductManager
    {
        IEnumerable<Product> SearchProducts(string wildCardString);
        Product SearchProducts(Guid id);
        Guid AddProduct(Product product);
        Product AddInventory(Product product);
    }
}
