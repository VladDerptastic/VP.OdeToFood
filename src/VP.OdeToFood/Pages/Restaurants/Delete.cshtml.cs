using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VP.OdeToFood.Data;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData restaurantData;

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            restaurantData.DeleteRestaurant(restaurantId, out var restaurant);
            restaurantData.Commit();

            if (restaurant == null)
                return RedirectToPage("./NotFound");

            //temp message living only for the next request
            TempData["Message"] = $"{restaurant.Name} was deleted.";
            return RedirectToPage("./List");
        }
    }
}