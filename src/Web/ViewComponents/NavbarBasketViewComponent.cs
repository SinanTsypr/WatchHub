using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class NavbarBasketViewComponent : ViewComponent
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public NavbarBasketViewComponent(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketViewModelService.GetBasketViewModelAsync();
            return View(basket);
        }
    }
}
