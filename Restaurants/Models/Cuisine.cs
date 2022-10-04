using System.Collections.Generic;

namespace Restaurants.Models
{ 
  public class Cuisine
  {
    public int CuisineId { get; set; }
    public string CuisineName { get; set; }
    public virtual ICollection<Restaurant> RestaurantsList { get; set; }
    
    public Restaurant()
    {
      this.RestaurantsList = new HashSet<Restaurant>();
    }
  }
}