namespace Shopex.Infrastructure.DB.Model
{
    public class DeliveryFees
    {
        public int fee_id { get; set; }
        public string name { get; set; }
        public decimal? min { get; set; }
        public decimal? max { get; set; }
        public decimal? price { get; set; }
        public bool is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }

    }
}
