using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Lagoon.Web.Controllers;
public class VillaController : Controller
{
  private readonly IRepoVilla _repo;
  public VillaController(IRepoVilla repo)
  {
     _repo = repo;
  }
  public IActionResult Index()
  {
     var villas = _repo.GetAll();
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
         _repo.Add(obj);
         _repo.Save();
         TempData["success"] = "Record Created Successfully";
         return RedirectToAction("Index", "Villa");
      }
      if(obj.Name == obj.Desc)
      {
         ModelState.AddModelError("","The Desc can't exactly match the Name.");
         
         ModelState.AddModelError("desc","The Desc can't exactly match the Name.");
      }
      TempData["error"] = "Record not Created";
      return View();
  }
  public IActionResult Update(int id)
  {
   Villa? obj = _repo.Get(y => y.ID == id, null);
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
      _repo.Update(obj);
      _repo.Save();
       TempData["success"] = "Record Updated Successfully";
      return RedirectToAction("Index");
     }
     TempData["success"] = "Record not Updated";
     return View();
  }
  public IActionResult Delete(int id)
  {
   Villa? obj = _repo.Get(x => x.ID == id);
   if(obj == null)
   {
      return RedirectToAction("Error", "Home");
   }
   return View(obj);
  }
  [HttpPost]
  public IActionResult Delete(Villa obj)
  {
     Villa? objDB = _repo.Get(x => x.ID == obj.ID);
     if(objDB is not null)
     {
      _repo.Remove(objDB);
      _repo.Save();
      TempData["success"] = "Record Deleted Successfully";
      return RedirectToAction("Index");
     }
     TempData["error"] = "Record not Deleted";
     return View();
  }

}