using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Lagoon.Domain.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lagoon.Web.Controllers;
public class AmenityController : Controller
{
  private readonly IUnitOfWork _uow;
  public AmenityController(IUnitOfWork uow)
  {
    _uow = uow;
  }
  public IActionResult Index()
  {
    var data = _uow.Amenity.GetAll(include: "Villa").ToList();
    return View(data);
  }
  private VM_Amenity GetVM(Amenity D = null)
  {
    return new VM_Amenity
    {
      VillaList = _uow.Villa.GetAll().ToList()
        .Select(x => new SelectListItem
        {
          Text = x.Name,
          Value = x.ID.ToString(),
        }),
      D = D
    };
  }
  public IActionResult Create()
  {
    return View(GetVM());
  }
  [HttpPost]
  public IActionResult Create(VM_Amenity obj)
  {
    // ModelState.Remove("Villa");
    var data = _uow.Amenity.Any(x => obj.D != null && x.VillaId == obj.D.ID);
    if (ModelState.IsValid && !data && obj.D is not null)
    {
      _uow.Amenity.Add(obj.D);
      _uow.Save();
      TempData["success"] = "Record Created Successfully";
      return RedirectToAction("Index", "Amenity");

    }
    TempData["error"] = data ? "Record Already Exsits" : "Record not Created";
    obj.VillaList = GetVM().VillaList;
    return View(obj);
  }
  public IActionResult Update(int id)
  {
    VM_Amenity result = GetVM();
    result.D = _uow.Amenity.Get(x => x.ID == id);
    if (result.D == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(result);
  }
  [HttpPost]
  public IActionResult Update(VM_Amenity obj)
  {
    bool hasVilla = _uow.Amenity.Any(y => y.ID == obj.D.ID);
    Console.WriteLine(hasVilla);
    Console.WriteLine(obj.D.ID);
    if (ModelState.IsValid && obj.D != null && obj.D.VillaId > 0)
    {
      _uow.Amenity.Update(obj.D);
      _uow.Save();
      TempData["success"] = "Record Updated Successfully";
      return RedirectToAction("Index");
    }
    obj.VillaList =  GetVM().VillaList;
    TempData["error"] = "Record not Updated";
    return View(obj);
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
  public IActionResult Delete(Villa obj)
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