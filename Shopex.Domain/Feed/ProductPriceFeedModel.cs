namespace Shopex.Domain.Feed
{
    public  class ProductPriceFeedModel: BaseFeedHeader
    {
        public string upc { get; set; }
        public string? size1 { get; set; }
        public string? size2 { get; set; }
        public string? pack_range { get; set; }
        public string? price { get; set; }
        public bool is_active { get; set; }
        public ProductPriceFeedModel()
        {
            IgnoreHeader = true;
        }
    }
}
