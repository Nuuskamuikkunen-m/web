using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Notes.Web.PL.Models;
using System.Security.Claims;
using Notes.BLLIntefaces;

namespace Notes.Web.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private INotesLogic _notesLogic;

        public AuthController(ILogger<AuthController> logger, INotesLogic notesLogic)
        {
            _logger = logger;
            _notesLogic = notesLogic;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                if (await IsValidAccountData(accountModel.Login, accountModel.Password))
                {
                    await Authenticate(accountModel.Login);

                    return RedirectToAction("GetUsersNote", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or password");
            }

            return View(accountModel);
        }

        [HttpGet]
        public IActionResult Registered()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registered(AccountUserModel model)
        {
            if (ModelState.IsValid)
            {
                var name = model.Name;
                var phoneNumber = model.PhoneNumber;
                var login = model.Login;
                var password = model.Password;
                var reg = model.Reg;

                if (name != null && phoneNumber != null && login != null && password != null)
                {
                    await _notesLogic.AddUser(name, reg, login, password, phoneNumber);


                    await Authenticate(model.Login);
                    return RedirectToAction("GetUsersNote", "Home");
                }
                else
                    ModelState.AddModelError("", "Fill in all the fields");
            }

            return View();

        }

        private async Task<bool> IsValidAccountData(string login, string password)
        {

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return false;
            if (!(await _notesLogic.CheckAccount(login, password)))
                return false;

            return true;
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
