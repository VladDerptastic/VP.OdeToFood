using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using VP.OdeToFood.Data;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        #region Fields
        private readonly ILogger<ListModel> _logger;
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        #endregion

        #region Properties
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        #endregion

        #region Bound Properties
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }
        #endregion

        public ListModel(ILogger<ListModel> logger, IConfiguration config, IRestaurantData restaurantData)
        {
            _logger = logger;
            _config = config;
            _restaurantData = restaurantData;
        }

        public void OnGet()
        {
            //var query = HttpContext.Request.Query["searchQuery"]; => Another way to get the data from the querry that led to this page
            Message = _config["Message"];

            if (string.IsNullOrEmpty(SearchQuery) == false)
                Restaurants = _restaurantData.GetRestaurantsByName(SearchQuery);
            else
                Restaurants = _restaurantData.GetAllRestaurants();
        }
    }
}