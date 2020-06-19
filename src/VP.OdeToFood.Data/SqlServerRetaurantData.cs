using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Data
{
    public class SqlServerRetaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlServerRetaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        //Reconciles all changes between the db and the context
        public int Commit()
            => db.SaveChanges();

        public bool DeleteRestaurant(int id, out Restaurant restaurant)
        {
            var restarauntToDel = GetRestaurantById(id);
            if (restarauntToDel != null)
            {
                db.Restaurants.Remove(restarauntToDel);
                restaurant = restarauntToDel;
                return true;
            }
            restaurant = null;
            return false;
        }

        public IEnumerable<Restaurant> GetAllRestaurants() 
            => db.Restaurants.ToList();

        public Restaurant GetRestaurantById(int id) 
            => db.Restaurants.Find(id);

        public IEnumerable<Restaurant> GetRestaurantsByName(string nameQuery) 
            => db.Restaurants.Where(x => x.Name.Contains(nameQuery) || string.IsNullOrEmpty(nameQuery)).OrderBy(x => x.Name);

        public Restaurant UpdateRestaurant(Restaurant updatedObject)
        {
            //.Attach() => Attach is used to repopulate a context with an entity that is known to already exist in the database. (https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset.attach?view=entity-framework-6.2.0)
            var entity = db.Restaurants.Attach(updatedObject);
            //EntityState.Modified => Tell EF that the object is fully changed (except the ID) so it updates all data (when Commit() is called).
            entity.State = EntityState.Modified;
            return updatedObject;
        }
    }
}
