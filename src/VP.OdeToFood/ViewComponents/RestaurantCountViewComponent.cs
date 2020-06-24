using Microsoft.AspNetCore.Mvc;
using System;
using VP.OdeToFood.Data;

namespace VP.OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;
        private DateTime lastCheck;
        private int cachedCount;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
            
            //initialize once
            lastCheck = DateTime.UtcNow;
            cachedCount = restaurantData.GetRestaurantCount();
        }

        public IViewComponentResult Invoke()
        {
            if (DateTime.UtcNow >= lastCheck.AddMinutes(10)) //refresh the cache every 10 minutes
                cachedCount = restaurantData.GetRestaurantCount();

            return View("Count", cachedCount);
        }
    }
}
