using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.models;

namespace InfyInsight.business.contract
{
    public interface IProductsManager
    {
        IEnumerable<Product> SearchProducts(string wildCardString);
        IEnumerable<Product> SearchProducts(string name);
        
    }
}
