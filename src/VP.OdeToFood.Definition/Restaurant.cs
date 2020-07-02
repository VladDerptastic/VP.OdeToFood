using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace VP.OdeToFood.Definition
{
    public class Restaurant //: IValidatableObject - Another possibility over the Attributes
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CuisineType Cuisine { get; set; }
    }
}
