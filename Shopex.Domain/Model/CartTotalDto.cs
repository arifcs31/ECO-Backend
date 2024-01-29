using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Domain.Model
{
    public class CartTotalDto
    {
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalTax { get; set; }
        public decimal DeliveryFee { get; set; }
        public float DeliveryPercentage { get; set; }
        public float TaxPercentage { get; set; }
        public decimal Count { get; set; }

        public IEnumerable<Carts> CartIems { get; set; }
    }
}
