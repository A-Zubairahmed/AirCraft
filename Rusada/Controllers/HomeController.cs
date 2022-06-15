using Microsoft.AspNetCore.Mvc;
using Rusada.Models;
using Rusada.Service;
using System.Diagnostics;

namespace Rusada.Controllers
{
    public class HomeController : Controller
    {
       private readonly IAircraft _airCraftService;

        public HomeController(IAircraft airCraftService)
        {
            _airCraftService = airCraftService;
        }

        public IActionResult Index()
        {
            var result = _airCraftService.GetAirCrafts();
            return View(result);
        }
        public IActionResult Create()
        {
            AirCraftViewModel airCraftView = new AirCraftViewModel();
            return View(airCraftView);
        }
        public IActionResult Details(int Id)
        {
           var detail= _airCraftService.GetAirCraft(Id);
            return View(detail);
        }
        public IActionResult Delete(int Id)
        {
            var detail = _airCraftService.GetAirCraft(Id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Edit(int Id)
        {
            var detail = _airCraftService.GetAirCraft(Id);
            return View("../Home/Create", detail);
        }
        [HttpPost]
        public ActionResult Submit(AirCraftViewModel airCraft)
        {
            _airCraftService.Create(airCraft);
            return RedirectToAction("Index", "Home");
        }
            public ActionResult GetAircrafts()
        {
            var result = _airCraftService.GetAirCrafts();
            return Json(result);
        }
       
    }
}