using AnimalShelter.Models;
using Application.Extensions;
using Application.Interfaces;
using Application.Utilities;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AnimalShelter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetService petService;
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public HomeController(ILogger<HomeController> logger, IPetService petService, IUserService userService, IRoleService roleService)
        {
            _logger = logger;
            this.petService = petService;
            this.userService = userService;
            this.roleService = roleService;
        }

        public IActionResult Index()
        {
            List<Pet> pets = null;
            try
            {
                pets = petService.GetApprovedPets();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(pets);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            User user = null;
            try
            {
                user = userService.GetUser(email, AppUtilities.EncryptSHA256(password));
                if (user == null)
                {
                    ViewBag.Warning = "Email veya şifre yanlış!!";
                }
                else
                {
                    HttpContext.Session.Remove("User");
                    HttpContext.Session.Remove("UserID");
                    HttpContext.Session.SetObjectAsJson("User", user);
                    HttpContext.Session.SetInt32("UserID", user.ID);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if(user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                if (!AppUtilities.IsValidEmail(user.Email))
                {
                    ViewBag.Warning = "Email formatı yanlış!!";
                }
                else if((user.Password).Length <= 2)
                {
                    ViewBag.Warning = "Parola çok kısa!!";
                }
                else
                {
                    user.RoleID = roleService.GetRoleID("User");
                    user.Password = AppUtilities.EncryptSHA256(user.Password);
                    user = userService.SaveUser(user);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (user.ID > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NonFound() 
        {
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            try
            {
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}