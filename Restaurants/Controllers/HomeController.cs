using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using System.Collections.Generic;

namespace Restaurants.Collections
{
  public class HomeController : controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}