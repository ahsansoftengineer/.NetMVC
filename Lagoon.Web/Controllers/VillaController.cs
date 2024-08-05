using Lagoon.Infra.Data;
using Microsoft.AspNetCore.Mvc;
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
}