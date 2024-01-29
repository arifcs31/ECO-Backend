using Shopex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Infrastructure.DB.Model
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
