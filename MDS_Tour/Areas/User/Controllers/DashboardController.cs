﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if(values!=null)
            {
                ViewBag.userName = values.Name +" "+values.Surname;
                ViewBag.userImage = values.Image;
                return View();
            }
            else
            {
                return View();
            }
           
        }
        public async Task<IActionResult> UserDashboard()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (values != null)
            {
                ViewBag.userNameSurname = values.Name +" "+ values.Surname;
                ViewBag.userName = values.UserName;
                ViewBag.userImage = values.Image;
                ViewBag.userPhone = values.PhoneNumber;
                ViewBag.userMail = values.Email;
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
