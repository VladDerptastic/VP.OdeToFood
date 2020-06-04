using System.Collections.Generic;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }
}
