

namespace Shopex.Domain.Model
{
    public class Carts
    {
        public int cart_id { get; set; }
        public int? user_id { get; set; }
        public int? session_id { get; set; }
        public int? product_price_id { get; set; }
        public int? product_id { get; set; }
        public int address_id { get; set; }
        public decimal? price { get; set; }
        public int? qty { get; set; }
        public decimal? total_price { get; set; }
        public int? count { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public Products? product { get; set; }


    }
}
