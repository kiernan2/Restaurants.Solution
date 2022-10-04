using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Restaurants.Models;

namespace Restaurants.Controllers
{
  public class CuisineController : Controller
  {
    private readonly RestaurantsContext _db;

    public CuisineController(RestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisine.ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisine.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    public ActionResult Create()
    {
      return View;
    }

    [HttpPost]
    public ActionResult Create(Cuisine Cuisine)
    {
      _db.Cuisine.Add(type);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Cuisine thisCuisine = _db.Cuisine.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
      return View(thisTCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      _db.Entry(Cuisine).State = EntryState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Cuisine thisCuisine = _db.Cuisine.FirstOrDefault(Cuisine => Cuisine.CuisineId);
      return View(thisCuisine);
    }

    // [HttpPost, ActionResult("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   Cuisine thisCuisine =_db.Cuisine.FirstOrDefault(Cuisine => Cuisine.CuisineId);
    //   _db.Cuisine.Remove(thisCuisine);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}