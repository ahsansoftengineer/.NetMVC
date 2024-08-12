using System.Text.Json;
using Lagoon.App.Common;
using Lagoon.Domain.VM;
using Microsoft.AspNetCore.Mvc;

namespace Lagoon.Web.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly IUnitOfWork _uow;
  public HomeController(
    ILogger<HomeController> logger,
    IUnitOfWork uow
    ):base()
  {
    _logger = logger;
    _uow = uow;
  }
  public IActionResult Index()
  {
    VM_Home homeVM = new()
    {
      VillaList = _uow.Villa.GetAll(include: "VillaAmenity"),
      Night = 1,
      CheckInDate = DateOnly.FromDateTime(DateTime.Now),
      CheckOutDate = DateOnly.FromDateTime(DateTime.Now),
    };
    // Console.WriteLine(JsonSerializer.Serialize(homeVM));
    return View(homeVM);
  }

  public IActionResult Privacy()
  {

    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View();
  }
  // public IActionResult Error()
  // {
  //   return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  // }
}
