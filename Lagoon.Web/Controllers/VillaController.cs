using System.Diagnostics;
using Lagoon.Domain.Entity;
using Lagoon.Infra.Data;
using Lagoon.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Lagoon.Web.Controllers;
public class VillaController : Controller
{
  private readonly AppDBContext _db;
  public VillaController(AppDBContext db)
  {
     _db = db;
  }
  public IActionResult Index()
  {
     var villas = _db.Villas.ToList();
     return View(villas);
  }
  public IActionResult Create() 
  {
   return View();
  }
  [HttpPost]
  public IActionResult Create(Villa obj)
  {

      if(ModelState.IsValid) 
      { 
         _db.Villas.Add(obj);
         _db.SaveChanges();
         return RedirectToAction("Index", "Villa");
      }
      if(obj.Name == obj.Desc)
      {
         ModelState.AddModelError("","The Desc can't exactly match the Name.");
         
         ModelState.AddModelError("desc","The Desc can't exactly match the Name.");
      }
      return View();
  }
  public IActionResult Update(int id)
  {
   Villa? obj = _db.Villas.FirstOrDefault(x => x.ID == id);
   if(obj == null)
   {
      return RedirectToAction("Error", "Home");
   }
   return View(obj);
  }
  [HttpPost]
  public IActionResult Update(Villa obj)
  {
     if(ModelState.IsValid && obj.ID > 0)
     {
      _db.Villas.Update(obj);
      _db.SaveChanges();
      return RedirectToAction("Index");
     }
     return View();
  }

}