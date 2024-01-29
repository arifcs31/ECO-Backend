using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Domain.Dto
{
    public record DataFilterDto
    {
        public int PageNo { get; set; } = 0;
        public int PageSize { get; set; } = 1000;  
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public string? column { get; set; }
        public string? condition { get; set; }
        public string? status { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
