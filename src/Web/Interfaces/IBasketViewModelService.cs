using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetBasketViewModelAsync();
        Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity);
        Task EmptyBasketAsync();
        Task RemoveItemAsync(int productId);
        Task<BasketViewModel> UpdateQuantities(Dictionary<int, int> quantities);
        Task TransferBasketAsync();
    }
}
