using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Restaurants.Models;

namespace Restaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly RestaurantsContext _db;

    public RestaurantsController(RestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Create()
    {
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View();
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisine, "CuisineId", "Name");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    // [HttpPost, ActionResult("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    //   _db.Restaurants.Remove(thisRestaurant);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisine.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}