using Lagoon.App.Common;
using Lagoon.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Lagoon.Web.Controllers;
public class VillaController : Controller
{
  //  private readonly IRepoVilla _repo;
  private readonly IUnitOfWork _uow;
  private readonly IWebHostEnvironment _webHostEnvironment;
  public VillaController(
   // IRepoVilla repo
   IUnitOfWork uow,
   IWebHostEnvironment webHostEnvironment
   )
  {
    this._uow = uow;
    _webHostEnvironment = webHostEnvironment;
    //  _repo = repo;
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
    if (ModelState.IsValid)
    {
      SaveImgInDir(ref obj);
      _uow.Villa.Add(obj);
      _uow.Save();
      TempData["success"] = "Record Created Successfully";
      return RedirectToAction("Index", "Villa");
    }
    if (obj.Name == obj.Desc)
    {
      ModelState.AddModelError("", "The Desc can't exactly match the Name.");
      ModelState.AddModelError("desc", "The Desc can't exactly match the Name.");
    }
    TempData["error"] = "Record not Created";
    return View();
  }


  public IActionResult Update(int id)
  {
    Villa? obj = _uow.Villa.Get(y => y.ID == id, null);
    if (obj == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(obj);
  }
  [HttpPost]
  public IActionResult Update(Villa obj)
  {
    if (ModelState.IsValid && obj.ID > 0)
    {
      DeleteFile(obj);
      SaveImgInDir(ref obj);
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
    if (obj == null)
    {
      return RedirectToAction("Error", "Home");
    }
    return View(obj);
  }
  [HttpPost]
  public IActionResult Delete(Villa obj)
  {
    Villa? objDB = _uow.Villa.Get(x => x.ID == obj.ID);
    if (objDB is not null)
    {
      DeleteFile(objDB, true);
      _uow.Villa.Remove(objDB);
      _uow.Save();
      TempData["success"] = "Record Deleted Successfully";
      return RedirectToAction("Index");
    }
    TempData["error"] = "Record not Deleted";
    return View();
  }
  private void SaveImgInDir(ref Villa obj)
  {
    if (obj.Image != null)
    {
      string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
      string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\VillaImage");
      using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
      {
        obj.Image.CopyTo(fileStream);
        obj.ImageUrl = @"\Images\VillaImage\" + fileName;
      }

    }
    else if(string.IsNullOrEmpty(obj.ImageUrl))
    {
      obj.ImageUrl = "https://placehold.co/600x400";
    }
  }

  private void DeleteFile(Villa obj, bool isDel = false)
  {
    if (!string.IsNullOrEmpty(obj.ImageUrl) && (obj.Image != null || isDel))
    {
      var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
      if (System.IO.File.Exists(oldImagePath))
      {
        System.IO.File.Delete(oldImagePath);
      }
    }
  }

}