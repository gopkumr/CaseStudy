using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfyInsight.models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public User User { get; set; }
        public Dictionary<Product, int> Items { get; set; }
        public Address ShippingAddress { get; set; }
        public PricingInformation PriceInformation { get; set; }
    }
}
