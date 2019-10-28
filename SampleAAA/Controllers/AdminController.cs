using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleAAA.Models;

namespace SampleAAA.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IPersonRepository personRepository;
        private readonly UserManager<MyUser> userManager;

        public AdminController(IPersonRepository personRepository,UserManager<MyUser> userManager)
        {
            this.personRepository = personRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        public  IActionResult AddUser(int id)
        {
            var person = personRepository.SearchPersonById(id);
            if (person != null) {
                UserViewModel usr = new UserViewModel
                {
                    UserName = person.Name,
                    Email = person.Email,
                    FullName = person.Name + " " + person.Family,

                };
                return View(usr);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel userView)
        {
            if (ModelState.IsValid)
            {
                MyUser user = new MyUser
                {
                    UserName = userView.UserName,
                    Email = userView.Email,
                    FullName = userView.FullName
                };
                IdentityResult result = await userManager.CreateAsync(user, userView.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return View(userView);
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}