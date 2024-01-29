namespace Shopex.Infrastructure.DB.Model
{
    public class Address
    {
        public int address_id { get; set; }
        public string? reference { get; set; }
        public string? phone { get; set; }
        public string? contact_name { get; set; }
        public string? region { get; set; }
        public string? post_code { get; set; }
        public string?  company_name { get; set; }
        public string? address { get; set; }
        public string? town { get; set; }
        public string? country { get; set; }
        public int? user_id { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public Users? user { get; set; }
        public string? type { get; set; }
        public ICollection<Carts> carts { get; set; }
        public ICollection<Orders> orders { get; set; }

    }
}
