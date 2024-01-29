
namespace Shopex.Domain.Model
{
    public class OrderLogs
    {
        public int order_log_id { get; set; }
        public string? error { get; set; }
        public int? user_id { get; set; }
        public string? request { get; set; }
        public string? extra_info { get; set; }
        public string? external_id { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }

    }
}
