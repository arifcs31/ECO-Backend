using Shopex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Infrastructure.DB.Model
{
    public class Banners
    {
        public int banner_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public BannerTypes type { get; set; }
        public string image_url { get; set; }
        public string alt_desc { get; set; }
        public string link_to { get; set; }
        public BannerPlacements placement { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }

    }
}
