using Lagoon.Domain.Entity;
using Lagoon.Domain.VM;
using Lagoon.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lagoon.Web.Controllers;
public class VillaNumberController : Controller
{
  private readonly AppDBContext _db;
  public VillaNumberController(AppDBContext db)
  {
    _db = db;
  }
  public IActionResult Index()
  {
    var data = _db.VillaNumber.Include(y => y.Villa).ToList();
    return View(data);
  }
  private VillaNumberVM GetVM(VillaNumber D = null)
  {
    return new VillaNumberVM
    {
      VillaList = _db.Villas.ToList()
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
  public IActionResult Create(VillaNumberVM obj)
  {
    // ModelState.Remove("Villa");
    var data = _db.VillaNumber.Any(x => x.Villa_Number == obj.D.Villa_Number);
    if (ModelState.IsValid && !data)
    {
      _db.VillaNumber.Add(obj.D);
      _db.SaveChanges();
      TempData["success"] = "Record Created Successfully";
      return RedirectToAction("Index", "VillaNumber");

    }
    TempData["error"] = data ? "Record Already Exsits" : "Record not Created";
    obj.VillaList = GetVM().VillaList;
    return View(obj);
  }
  public IActionResult Update(int id)
  {
    VillaNumberVM result = GetVM();
    result.D = _db.VillaNumber.FirstOrDefault(x => x.Villa_Number == id);
    if (result.D == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(result);
  }
  [HttpPost]
  public IActionResult Update(VillaNumberVM obj)
  {
    if (ModelState.IsValid && obj.D.VillaId > 0)
    {
      _db.VillaNumber.Update(obj.D);
      _db.SaveChanges();
      TempData["success"] = "Record Updated Successfully";
      return RedirectToAction("Index");
    }
    obj.VillaList =  GetVM().VillaList;
    TempData["error"] = "Record not Updated";
    return View(obj);
  }

  public IActionResult Delete(int id)
  {
    VillaNumber? obj = _db.VillaNumber.FirstOrDefault(x => x.Villa_Number == id);
    if (obj == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(obj);
  }
  [HttpPost]
  public IActionResult Delete(Villa obj)
  {
    VillaNumber? objDB = _db.VillaNumber.FirstOrDefault(x => x.Villa_Number == obj.ID);
    if (objDB is not null)
    {
      _db.VillaNumber.Remove(objDB);
      _db.SaveChanges();
      TempData["success"] = "Record Deleted Successfully";
      return RedirectToAction("Index");
    }
    TempData["error"] = "Record not Deleted";
    return View();
  }

}