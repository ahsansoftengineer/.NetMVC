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
         TempData["success"] = "The Villa has been Created Successfully";
         return RedirectToAction("Index", "Villa");
      }
      if(obj.Name == obj.Desc)
      {
         ModelState.AddModelError("","The Desc can't exactly match the Name.");
         
         ModelState.AddModelError("desc","The Desc can't exactly match the Name.");
      }
      TempData["success"] = "The Villa could not be Created";
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
       TempData["success"] = "The Villa has been Updated Successfully";
      return RedirectToAction("Index");
     }
     TempData["success"] = "The Villa could not be Updated";
     return View();
  }

  public IActionResult Delete(int id)
  {
   Villa? obj = _db.Villas.FirstOrDefault(x => x.ID == id);
   if(obj == null)
   {
      return RedirectToAction("Error", "Home");
   }
   return View(obj);
  }
  [HttpPost]
  public IActionResult Delete(Villa obj)
  {
     Villa? objDB = _db.Villas.FirstOrDefault(x => x.ID == obj.ID);
     if(objDB is not null)
     {
      _db.Villas.Remove(objDB);
      _db.SaveChanges();
      TempData["success"] = "The Villa has been Deleted Successfully";
      return RedirectToAction("Index");
     }
           TempData["error"] = "The Villa could not be Deleted";
     return View();
  }

}