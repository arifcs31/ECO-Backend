using Shopex.Domain.Model;

namespace Shopex.Domain.Dto
{
    public  class OrderResponseDto
    {
        public IEnumerable<Orders> orders { get; set; }
        public int? recordsTotal { get; set; }
        public int? recordsFiltered { get; set; }
    }
}
