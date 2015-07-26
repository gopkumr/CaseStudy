using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfyInsight.models
{
    public class PricingInformation
    {
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal Discount { get; set; }
        public Dictionary<string, decimal> OtherCharges { get; set; }
        public decimal Total { get; set; }
    }
}
