using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfyInsight.business.contract;

namespace InfyInsight.business
{
    public class ProductManager : IProductManager
    {
        public IEnumerable<InfyInsight.models.Product> SearchProducts(string wildCardString)
        {
            throw new NotImplementedException();
        }

        public InfyInsight.models.Product SearchProducts(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
