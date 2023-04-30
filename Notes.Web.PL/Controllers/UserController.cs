using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Notes.Common.Entities;
using Notes.Web.PL.Models;
using System.Security.Claims;
using Notes.BLLIntefaces;

namespace Notes.Web.PL.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private INotesLogic _notesLogic;

        public UserController(ILogger<UserController> logger, INotesLogic notesLogic)
        {
            _logger = logger;
            _notesLogic = notesLogic;
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> EditAccount(AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                var oldLogin = User.Identity.Name;
                var oldAccount = await _notesLogic.GetAccount(oldLogin);
                var login = accountModel.Login;
                var password = accountModel.Password;

                var account = new Account(oldAccount.Id, login, password);
                await _notesLogic.EditAccount(account);
                await Authenticate(account.Login);
                return RedirectToAction("GetUserAccount", "Home");
            }

            return View(accountModel);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var oldLogin = User.Identity.Name;
                var oldAccount = await _notesLogic.GetAccount(oldLogin);
                var name = userModel.Name;
                var reg = userModel.RegDate;
                var phoneNumber = userModel.PhoneNumber;

                var user = new User(oldAccount.Id, name, reg, phoneNumber);
                await _notesLogic.EditUser(user);
                return RedirectToAction("GetUserAccount", "Home");
            }

            return View(userModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
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
