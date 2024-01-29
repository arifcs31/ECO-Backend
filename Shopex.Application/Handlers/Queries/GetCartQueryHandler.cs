using LinqKit;
using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetCartQuery(int user_id) : IRequest<CartTotalDto> { };

    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartTotalDto>
    {
        private readonly AppConfiguration _appConfiguration;
        private readonly ICartRepository _cartRepository;
        private readonly IDeliverFeeRepository _deliverFeeRepository;
        public GetCartQueryHandler(AppConfiguration appConfiguration, IDeliverFeeRepository deliverFeeRepository,ICartRepository cartRepository)
        {
            _appConfiguration = appConfiguration;
            _deliverFeeRepository = deliverFeeRepository;
            _cartRepository = cartRepository;
        }
        public async Task<CartTotalDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var deliveryFees = await _deliverFeeRepository.Get();
            var result1 = await _cartRepository.Get(request.user_id);
            var result = result1.ToList();
            CartTotalDto cart = new CartTotalDto();

            result.ForEach(o => o.total_price = o.price * o.count);
            
            cart.SubTotal = Math.Round((decimal)result.Sum(i => i.total_price),2);
            var deliveryFee = deliveryFees.FirstOrDefault(i => i.min <= cart.SubTotal && i.max >= cart.SubTotal)?.price;
            if (deliveryFee != null)
            {
                cart.DeliveryFee = Math.Round((decimal)deliveryFee, 2);
                //cart.DeliveryPercentage = (float)deliveryFee;
                //cart.DeliveryFee = Math.Round((decimal)(cart.SubTotal * (deliveryFee / 100)),3);
            }
            else
            {
                deliveryFee = 0;
            }
            if (_appConfiguration.Vat > 0)
            {
                cart.TaxPercentage = (float)_appConfiguration.Vat;
                cart.TotalTax = Math.Round((cart.SubTotal + (decimal)deliveryFee) * (_appConfiguration.Vat / 100),2);
            }
            cart.Count = result.Count();
            cart.CartIems = result;
            
            cart.Total = Math.Round(cart.SubTotal + cart.TotalTax + cart.DeliveryFee,2);
            return cart;
        }
    }

}
