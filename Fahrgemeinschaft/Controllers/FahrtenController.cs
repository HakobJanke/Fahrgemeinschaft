using Fahrgemeinschaft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Fahrgemeinschaft.Controllers
{
    public class FahrtenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Save(FahrtenViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), model);
            }
            return RedirectToAction(nameof(ThankYou));
        }
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
