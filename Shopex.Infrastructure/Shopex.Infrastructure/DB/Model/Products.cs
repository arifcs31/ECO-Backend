namespace Shopex.Infrastructure.DB.Model
{
    public class Products
    {
        public int product_id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? upc { get; set; }
        public string? image_url { get; set; }
        public int? category_id { get; set; }
        public string? external_id { get; set; }
        public string? tech_description { get; set; }
        public string? brand { get; set; }
        public string? uses { get; set; }
        public string? link_upc { get; set; }
        public decimal? price { get; set; }
        public int? unit { get; set; }
        public int? sort { get; set; }
        public bool is_active { get; set; }
        public bool? show_on_landing { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }

        public Categories Category { get; set; }
        public ICollection<Product_Prices> product_prices { get; set; }
        public ICollection<Carts> carts { get; set; }
        public ICollection<Order_Lines> orderLines { get; set; }

    }
}
