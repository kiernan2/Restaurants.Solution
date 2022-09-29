using Microsoft.EntityFrameworkCore;

namespace Restaurants.Models
{
  public class RestaurantsContext : DbContext
  {
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Item> Item { get; set; }

    public ToDoListContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.useLazyLoadingProxies();
    }
  }
}