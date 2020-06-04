﻿using System.Collections.Generic;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        IEnumerable<Restaurant> GetRestaurantsByName(string nameQuery);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedObject);
        int Commit();
    }
}
