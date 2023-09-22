using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class SetQuantities
    {
        private readonly IRepository<Basket> _mockBasketRepo = Substitute.For<IRepository<Basket>>();
        private readonly IRepository<BasketItem> _mockBasketItemRepo = Substitute.For<IRepository<BasketItem>>();
        private readonly IRepository<Product> _mockProductRepo = Substitute.For<IRepository<Product>>();
        private readonly string _buyerId = "test-buyer-id";

        [Fact]
        public async Task ThrowsExceptionWhenQuantityIsNotPossitive()
        {
            var basketService = new BasketService(_mockBasketRepo, _mockBasketItemRepo, _mockProductRepo);

            Dictionary<int, int> quantities = new Dictionary<int, int>()
            {
                { 1, 3 },
                { 2, 0 },
                { 4, 1 }
            };

            await Assert.ThrowsAsync<NonPositiveQuantityException>(
                async () => await basketService.SetQuantitiesAsync(_buyerId, quantities));
        }
    }
}
