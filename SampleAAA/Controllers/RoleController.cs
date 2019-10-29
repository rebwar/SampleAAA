using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleAAA.Models;

namespace SampleAAA.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<MyUser> usermgr;

        public RoleController(RoleManager<IdentityRole> roleManager,UserManager<MyUser> usermgr)
        {
            this.roleManager = roleManager;
            this.usermgr = usermgr;
        }
        public IActionResult Index()
        {

            return View(roleManager.Roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([Required]string roleName)
        {
            IdentityResult result= await roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            return View(roleName);
        }
        public async Task<IActionResult> AddUsersToRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<MyUser> users = new List<MyUser>();
            foreach (MyUser myuser in usermgr.Users)
            {
                if(! await usermgr.IsInRoleAsync(myuser, role.Name))
                {
                    users.Add(myuser);
                }
            }
            ViewBag.RoleId = id;
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> AddUsersToRole(string RoleId,string[] users)
        {
            IdentityRole role = await roleManager.FindByIdAsync(RoleId);
            IdentityResult result;
            MyUser myuser;
            foreach (string userid in users)
            {
                myuser = await usermgr.FindByIdAsync(userid);
                if ((role != null) && (myuser != null))
                {
                   result=await usermgr.AddToRoleAsync(myuser, role.Name);
                    if(!result.Succeeded)
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                    }
                   
                }
            }
            if (ModelState.IsValid)
            {
               return RedirectToAction(nameof(Index));
            }
            else
            {
                return await AddUsersToRole(RoleId);
            }

        }
        public IActionResult RemoveUsersToRole(int id)
        {
            return View();
        }

    }
}