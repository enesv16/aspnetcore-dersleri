using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityApp.Models;
using IdentityApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace IdentityApp.Controllers
{

    public class AccountController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _sigInManager;

        public AccountController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> sigInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sigInManager = sigInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _sigInManager.SignOutAsync();

                    var result = await _sigInManager.PasswordSignInAsync(user, model.Password, model.RemeberMe, true);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);

                        return RedirectToAction("Index", "Home");
                    }
                    else if (result.IsLockedOut)
                    {
                        var lockoutDate = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = lockoutDate.Value - DateTime.UtcNow;
                        ModelState.AddModelError("",$"Hesabınız kitlendi, Lütfen {timeLeft.Minutes+1} dakika sonra deneyiniz.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email");
                }
            }


            return View(model);
        }


    }
}