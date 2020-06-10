using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VP.OdeToFood.Data;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        #region Fields
        private readonly IRestaurantData _restaurantData;
        #endregion

        #region Properties
        public Restaurant Restaurant { get; set; }
        [TempData]
        public string RedirectMessage { get; set; }
        #endregion

        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}