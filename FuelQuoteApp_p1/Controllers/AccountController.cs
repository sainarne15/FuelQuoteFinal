using FuelQuoteApp_p1.EntModels.Models;
using FuelQuoteApp_p1.Models.Account;
using FuelQuoteApp_p1.Provider;
using FuelQuoteApp_p1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuelQuoteApp_p1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IFuelQuoteProvider _FuelQuotePro;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IFuelQuoteProvider FuelQuotePro)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _FuelQuotePro = FuelQuotePro;
        }
        [HttpGet]
        [ExcludeFromCodeCoverage]
        public IActionResult Display()
        {
            return View();
        }

        [HttpGet]
        [ExcludeFromCodeCoverage]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ExcludeFromCodeCoverage]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                // Uses Key Derivation function To encrypt the password  (Default password encryption in Identity User)
                if (result.Succeeded)
                {
                    int userID = _FuelQuotePro.GetUserID(model.Email);
                    User userinfo = new User
                    {
                        Id = userID,
                        Email = model.Email
                    };

                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userinfo));

                    bool clientinfo = _FuelQuotePro.GetClientInfo(userID);
                    if (clientinfo)
                    {
                        return RedirectToAction("ClientDashBoard", "Client");
                    }
                    else
                    {
                        TempData["ClientProfileInfo"] = "Fill the profile details before requesting for a quote";
                        return RedirectToAction("ClientProfile", "Client");
                    }

                }
                ModelState.AddModelError(string.Empty, "Invalid Credentials! Please check and enter again");
            }
            return View(model);
        }

        [HttpGet]
        [ExcludeFromCodeCoverage]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ExcludeFromCodeCoverage]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Register registerInfo)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerInfo.Email, Email = registerInfo.Email };
                var result = await userManager.CreateAsync(user, registerInfo.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    User userinfo = new User
                    {
                        UserName = registerInfo.UserName,
                        Email = registerInfo.Email
                    };
                    _FuelQuotePro.AddUser(userinfo);

                    TempData["RegistrationSuccessful"] = "You're registered succesfully!";
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        [ExcludeFromCodeCoverage]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }

        public bool RegisterDataValidation(Register registerinfo)
        {
            bool flag = false;
            if ((registerinfo.UserName.Length <= 50) && (registerinfo.UserName != String.Empty))
            {
                if ((Regex.IsMatch(registerinfo.Email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*")) && (registerinfo.Email != String.Empty))
                {
                    if (registerinfo.Password == registerinfo.ConfirmPassword)
                    {
                        flag = true;
                    }
                }
            }
            else
            {
                flag = false;
            }

            return flag;
        }
    }
}