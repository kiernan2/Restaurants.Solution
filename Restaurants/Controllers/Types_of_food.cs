using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Ling;
using Restaurants.Models;

namespace Restaurants.Controllers
{
  public class Types_of_foodController : Controller
  {
    private readonly RestaurantsContext _db;

    public Types_of_foodController(RestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Types_of_food> model = _db.Type_of_food.ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      Types_of_food thisType_of_food = _db.Type_of_food.FirstOrDefault(Type_of_food => Type_of_food.type_of_foodId == id);
      return View(thisType_of_food);
    }

    public ActionResult Create()
    {
      return View
    }

    [HttpPost]
    public ActionResult Create(Types_of_food type_of_food)
    {
      _db.Types_of_food.Add(type);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Types_of_food thisType_of_food = _db.Types_of_food.FirstOrDefault(type_of_food => type_of_food.type_of_foodId == id);
      return View(thisType_of_food);
    }

    [HttpPost]
    public ActionResult Edit(Types_of_food type_of_food)
    {
      _db.Entry(type_of_food).State = EntryState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Types_of_food thisType_of_food = _db.type_of_food.FirstOrDefault(type_of_food => type_of_food.type_of_foodId);
      return View(thisType_of_food);
    }

    [HttpPost, ActionResult("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Types_of_food thisType_of_food =_db.type_of_food.FirstOrDefault(type_of_food => type_of_food.type_of_foodId);
      _db.type_of_food.Remove(thisType_of_food);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}