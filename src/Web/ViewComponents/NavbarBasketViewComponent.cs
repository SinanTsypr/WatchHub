using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class NavbarBasketViewComponent : ViewComponent
    {
        public NavbarBasketViewComponent()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // login olunmuşsa kullanıcı id, olunmamışsa cookilerde saklanan anonymousId, eğer o da yoksa şimdi üretilecek ve sonra cookie'lerde saklanacak bir benzersiz anon id parametre olarak sokulmalı
            return View();
        }
    }
}
