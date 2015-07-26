using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfyInsight.models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public KeyValuePair<string, string> Properties { get; set; }
    }
}
