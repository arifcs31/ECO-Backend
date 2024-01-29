using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Domain.Feed
{
    public  class CategoryFeedModel: BaseFeedHeader
    {
        public string category_id { get; set; }
        public string parent_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public int? sort { get; set; }
        public CategoryFeedModel()
        {
            IgnoreHeader = true;
        }
    }
}
