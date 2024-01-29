namespace Shopex.Infrastructure.DB.Model
{
    public class Order_Lines
    {
        public int order_line_id { get; set; }
        public int? order_id { get; set; }
        public int? product_id { get; set; }
        public int? product_price_id { get; set; }
        public int? count { get; set; }
        public decimal? price { get; set; }
        public int? qty { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public Products? product { get; set; }
        public Orders? order { get; set; }
        public Product_Prices? productPrice { get; set; }

    }
}
