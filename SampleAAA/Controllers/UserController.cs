using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleAAA.Models;

namespace SampleAAA.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<MyUser> userManager;
        private readonly SignInManager<MyUser> signInManager;

        public UserController(UserManager<MyUser> userManager,SignInManager<MyUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if(ModelState.IsValid)
            {
                await signInManager.SignOutAsync();
               MyUser user = await userManager.FindByEmailAsync(login.Email);
                if(user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, login.Password, false,false);
                    if(result.Succeeded)
                    {
                        return Redirect("/admin/index");
                    }
                    else
                    {
                        ModelState.AddModelError("LoginError", "Email or password is invalid");
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Your information not found in our Database!");
                }
            }
            return View(login);
        }
    }
}