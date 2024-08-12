using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Lagoon.Domain.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lagoon.Web.Controllers;
public class VillaNumberController : Controller
{
  private readonly IUnitOfWork _uow;
  public VillaNumberController(IUnitOfWork uow)
  {
    _uow = uow;
  }
  public IActionResult Index()
  {
    var data = _uow.VillaNumber.GetAll(x => true, "Villa").ToList();
    return View(data);
  }
  private VM_VillaNumber GetVM(VillaNumber D = null)
  {
    return new VM_VillaNumber
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
  public IActionResult Create(VM_VillaNumber obj)
  {
    // ModelState.Remove("Villa");
    var data = _uow.VillaNumber.Any(x => obj.D != null && x.Villa_Number == obj.D.Villa_Number);
    if (ModelState.IsValid && !data && obj.D is not null)
    {
      _uow.VillaNumber.Add(obj.D);
      _uow.Save();
      TempData["success"] = "Record Created Successfully";
      return RedirectToAction("Index", "VillaNumber");

    }
    TempData["error"] = data ? "Record Already Exsits" : "Record not Created";
    obj.VillaList = GetVM().VillaList;
    return View(obj);
  }
  public IActionResult Update(int id)
  {
    VM_VillaNumber result = GetVM();
    result.D = _uow.VillaNumber.Get(x => x.Villa_Number == id);
    if (result.D == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(result);
  }
  [HttpPost]
  public IActionResult Update(VM_VillaNumber obj)
  {
    bool hasVilla = _uow.VillaNumber.Any(y => y.Villa_Number == obj.D.Villa_Number);
    
    if (ModelState.IsValid && obj.D != null && obj.D.VillaId > 0)
    {
      _uow.VillaNumber.Update(obj.D);
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
    VillaNumber? obj = _uow.VillaNumber.Get(x => x.Villa_Number == id);
    if (obj == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(obj);
  }
  [HttpPost]
  public IActionResult Delete(Villa obj)
  {
    VillaNumber? objDB = _uow.VillaNumber.Get(x => x.Villa_Number == obj.ID);
    if (objDB is not null)
    {
      _uow.VillaNumber.Remove(objDB);
      _uow.Save();
      TempData["success"] = "Record Deleted Successfully";
      return RedirectToAction("Index");
    }
    TempData["error"] = "Record not Deleted";
    return View();
  }

}