using System.ComponentModel.DataAnnotations;

namespace VP.OdeToFood.Definition
{
    public class Restaurant //: IValidatableObject - Another possibility
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
