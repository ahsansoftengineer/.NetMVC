using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Lagoon.Web.Controllers;
public class AmenityController : Controller
{
  private readonly IUnitOfWork _uow;
  public AmenityController(
   IUnitOfWork uow
   )
  {
    this._uow = uow;
    //  _repo = repo;
  }
  public IActionResult Index()
  {
    var data = _uow.Amenity.GetAll(x => true, "Villa").ToList();
    return View(data);
  }
  public IActionResult Create()
  {
    return View();
  }
  [HttpPost]
  public IActionResult Create(Amenity obj)
  {
    if (ModelState.IsValid)
    {
      _uow.Amenity.Add(obj);
      _uow.Save();
      TempData["success"] = "Record Created Successfully";
      return RedirectToAction("Index", "Amenity");
    }
    TempData["error"] = "Record not Created";
    return View();
  }


  public IActionResult Update(int id)
  {
    Amenity? obj = _uow.Amenity.Get(y => y.ID == id, null);
    if (obj == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(obj);
  }
  [HttpPost]
  public IActionResult Update(Amenity obj)
  {
    if (ModelState.IsValid && obj.ID > 0)
    {
      _uow.Amenity.Update(obj);
      _uow.Save();
      TempData["success"] = "Record Updated Successfully";
      return RedirectToAction("Index");
    }
    TempData["success"] = "Record not Updated";
    return View();
  }
  public IActionResult Delete(int id)
  {
    Amenity? obj = _uow.Amenity.Get(x => x.ID == id);
    if (obj == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(obj);
  }
  [HttpPost]
  public IActionResult Delete(Amenity obj)
  {
    Amenity? objDB = _uow.Amenity.Get(x => x.ID == obj.ID);
    if (objDB is not null)
    {
      _uow.Amenity.Remove(objDB);
      _uow.Save();
      TempData["success"] = "Record Deleted Successfully";
      return RedirectToAction("Index");
    }
    TempData["error"] = "Record not Deleted";
    return View();
  }
}