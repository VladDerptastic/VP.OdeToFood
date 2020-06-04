using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using VP.OdeToFood.Data;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        #region Fields
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        #endregion

        #region Properties
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        #endregion

        #region Bound Properties
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        #endregion

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        public IActionResult OnPost()
        {
            Restaurant = _restaurantData.UpdateRestaurant(Restaurant);
            _restaurantData.Commit();
            return Page();
        }
    }
}