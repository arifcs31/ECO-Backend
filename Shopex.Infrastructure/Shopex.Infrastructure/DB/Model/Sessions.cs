namespace Shopex.Infrastructure.DB.Model
{
    public class Sessions
    {
        public int session_id { get; set; }
        public string? browser { get; set; }
        public string? ip { get; set; }
        public bool is_active { get; set; }
        public DateTime? created { get; set; }
        public ICollection<Carts> carts { get; set; }

    }
}
