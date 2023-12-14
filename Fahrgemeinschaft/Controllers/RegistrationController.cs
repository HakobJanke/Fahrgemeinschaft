using Microsoft.AspNetCore.Mvc;
using Fahrgemeinschaft.Models;

namespace Fahrgemeinschaft.Controllers;

public class RegistrationController : Controller
{
    private readonly IDataStore dataStore;

    public RegistrationController(IDataStore dataStore)
    {
        this.dataStore = dataStore;
    }
    public IActionResult Save(RegistrationViewModel model)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View(nameof(Create), LoadModel());
        //}

        dataStore.CreateRegistration(model);

        return RedirectToAction(nameof(ThankYou));
    }

    public IActionResult ThankYou()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }
}
