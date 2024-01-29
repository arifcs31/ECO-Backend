namespace Shopex.Infrastructure.DB.Model
{
    public class Orders
    {
        public int order_id { get; set; }
        public decimal? sub_total { get; set; }
        public decimal? total { get; set; }
        public decimal? total_tax { get; set; }
        public decimal? delivery_fee { get; set; }
        public string? note { get; set; }
        public int? user_id { get; set; }
        public string? payment_reference { get; set; }
        public string? status { get; set; }
        public int? address_id { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public ICollection<Order_Lines>? orderLines{ get; set; }
        public Users? user { get; set; }
        public Address? address { get; set; }


    }
}
