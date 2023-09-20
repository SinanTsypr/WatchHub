using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await _basketViewModelService.GetBasketViewModelAsync();
            return View(basket);
        }

        [HttpPost]
        public async Task<ActionResult<BasketViewModel>> AddItem(int productId, int quantity = 1)
        {
            var basket = await _basketViewModelService.AddItemToBasketAsync(productId, quantity);
            return basket;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EmptyBasket()
        {
            await _basketViewModelService.EmptyBasketAsync();
            TempData["SuccessMessage"] = "Your basket is now empty.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            await _basketViewModelService.RemoveItemAsync(productId);
            TempData["SuccessMessage"] = "Item removed from basket.";
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([ModelBinder(Name ="quantities")] Dictionary<int, int> quantities)
        {
            await _basketViewModelService.UpdateQuantities(quantities);
            TempData["SuccessMessage"] = "Basket updated successfully.";
            return RedirectToAction("Index");
        }
    }
}
