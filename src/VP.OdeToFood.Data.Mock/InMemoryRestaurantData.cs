﻿using System.Collections.Generic;
using System.Linq;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Data.Mock
{
    /// <summary>
    /// In-memory implementation of IRestaurantData for local/UI testing purposes if needed.
    /// </summary>
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> Restaurants =
            new List<Restaurant>
            {
                new Restaurant(){ Id = 1, Location = "Copenhagen", Name = "Divan Kebap",  Cuisine = CuisineType.Arabic},
                new Restaurant(){ Id = 2, Location = "Roskilde", Name = "Namaste",  Cuisine = CuisineType.Indian},
                new Restaurant(){ Id = 3, Location = "Sofia", Name = "La Picolo Casa",  Cuisine = CuisineType.Italian},
                new Restaurant(){ Id = 4, Location = "Edinburgh", Name = "The Lucky Dragon",  Cuisine = CuisineType.Chinese},
                new Restaurant(){ Id = 5, Location = "Berlin", Name = "Sou Sushi",  Cuisine = CuisineType.Japanise},
            };

        public int Commit()
            => 0;

        public IEnumerable<Restaurant> GetAllRestaurants() 
            => Restaurants.OrderBy(x => x.Cuisine);

        public Restaurant GetRestaurantById(int id) 
            => Restaurants.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Restaurant> GetRestaurantsByName(string nameQuery) 
            => Restaurants.Where(x => x.Name.ToLower().Contains(nameQuery.ToLower())).OrderBy(x => x.Name);

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            Restaurants.Add(newRestaurant);
            newRestaurant.Id = Restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }

        public bool DeleteRestaurant(int id, out Restaurant restaurant)
        {
            var restaurantToDel = GetRestaurantById(id);
            if (restaurantToDel != null)
            {
                restaurant = restaurantToDel;
                return Restaurants.Remove(restaurantToDel);
            }
            restaurant = null;
            return false;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedObject)
        {
            var restaurant = Restaurants.SingleOrDefault(x => x.Id == updatedObject.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedObject.Name;
                restaurant.Location = updatedObject.Location;
                restaurant.Cuisine = updatedObject.Cuisine;
            }
            return restaurant;
        }

        public int GetRestaurantCount()
            => Restaurants.Count;
    }
}
