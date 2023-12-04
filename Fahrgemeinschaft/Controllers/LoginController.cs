using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fahrgemeinschaft.Models;
using Microsoft.AspNetCore.Identity;
//using NuGet.Protocol.Plugins;

namespace Fahrgemeinschaft.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly Authenticator authenticator;
        public LoginController(Authenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View(nameof(Index));
        }
        public async Task<IActionResult> DoLogin(LoginViewModel model, [FromQuery] string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), model);
            }
            if (!await authenticator.Login(model.Username!, model.Password!))
            {
                ModelState.AddModelError("", "Username or Password is not valid");
                return View(nameof(Index), model);
            }
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }

}
