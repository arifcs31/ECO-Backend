using Shopex.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Domain.Dto
{
    public  class BannerResponseDto
    {
        public IEnumerable<Banners> banners { get; set; }
        public int? recordsTotal { get; set; }
        public int? recordsFiltered { get; set; }
    }
}
