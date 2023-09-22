using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IRepository<Order> _orderRepo;

        public OrderService(IBasketService basketService, IRepository<Order> orderRepo)
        {
            _basketService = basketService;
            _orderRepo = orderRepo;
        }
        public async Task<Order> CreateOrderAsync(string buyerId, Address shippingAddress)
        {
            var basket = await _basketService.GetOrCreateBasketAsync(buyerId);

            if (basket.Items.Count == 0)
            throw new EmptyBasketException();

            Order order = new Order
            {
                ShipToAdress = shippingAddress,
                BuyerId = buyerId,
                Items = basket.Items.Select(x => new OrderItem()
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    UnitPrice = x.Product.Price,
                    PictureUri = x.Product.PictureUri,
                    Quantity = x.Quantity
                }).ToList()
            };

            return await _orderRepo.AddAsync(order);
        }
    }
}
