namespace Shopex.Infrastructure.DB.Model
{
    public class Product_Prices
    {
        public int product_price_id { get; set; }
        public int product_id { get; set; }
        public string? size1 { get; set; }
        public string? size2 { get; set; }
        public string? pack_range { get; set; }
        public string? external_product_id { get; set; }
        public decimal? price { get; set; }
        public bool is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public Products product{get;set;}
        public ICollection<Carts> carts { get; set; }
        public ICollection<Order_Lines> orderLines { get; set; }
    }
}
