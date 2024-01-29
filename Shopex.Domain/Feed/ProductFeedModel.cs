namespace Shopex.Domain.Feed
{
    public  class ProductFeedModel: BaseFeedHeader
    {
        public string upc { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? image_url { get; set; }
        public string? category_id { get; set; }
        public string? product_id { get; set; }
        public string? tech_description { get; set; }
        public string? brand { get; set; }
        public string? uses { get; set; }
        public string? sort { get; set; }
        public string? link_upc { get; set; }
        public decimal? price { get; set; }
        public bool is_active { get; set; }
        public bool show_on_landing { get; set; }
        public ProductFeedModel()
        {
            IgnoreHeader = true;
        }
    }
}
