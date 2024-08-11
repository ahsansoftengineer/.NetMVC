using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Lagoon.Web.Controllers;
public class VillaController : Controller
{
//   private readonly IRepoVilla _repo;
  private readonly IUnitOfWork _uow;
  public VillaController(
   // IRepoVilla repo
   IUnitOfWork uow

   )
  {
   this._uow = uow;
   //   _repo = repo;
  }
  public IActionResult Index()
  {
     var villas = _uow.Villa.GetAll();
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
         _uow.Villa.Add(obj);
         _uow.Save();
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
   Villa? obj = _uow.Villa.Get(y => y.ID == id, null);
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
      _uow.Villa.Update(obj);
      _uow.Save();
       TempData["success"] = "Record Updated Successfully";
      return RedirectToAction("Index");
     }
     TempData["success"] = "Record not Updated";
     return View();
  }
  public IActionResult Delete(int id)
  {
   Villa? obj = _uow.Villa.Get(x => x.ID == id);
   if(obj == null)
   {
      return RedirectToAction("Error", "Home");
   }
   return View(obj);
  }
  [HttpPost]
  public IActionResult Delete(Villa obj)
  {
     Villa? objDB = _uow.Villa.Get(x => x.ID == obj.ID);
     if(objDB is not null)
     {
      _uow.Villa.Remove(objDB);
      _uow.Save();
      TempData["success"] = "Record Deleted Successfully";
      return RedirectToAction("Index");
     }
     TempData["error"] = "Record not Deleted";
     return View();
  }
}