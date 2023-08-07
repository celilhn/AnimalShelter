using System;
using Application.Extensions;
using Application.Interfaces;
using Application.Utilities;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;


namespace Web.Controllers
{
    public class PanelLoginController : Controller
    {
        private readonly IUserService userService;
        public PanelLoginController(IUserService userService)
        {
            this.userService = userService;
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
            bool isAuthenticated = false;
            try
            {
                user = userService.GetUser(email, password);
                //user = userService.GetUser(user.Email, AppUtilities.EncryptSHA256(user.Password));
                if (user != null)
                {
                    isAuthenticated = true;
                    HttpContext.Session.SetObjectAsJson("AdminUser", user);
                }
                else
                {
                    TempData["AlertType"] = SweetAlertTypes.UserEmailPassWordInCorrect.ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = SweetAlertTypes.Error.ToString();
                Console.WriteLine(ex);
            }

            if (isAuthenticated)
            {
                return RedirectToAction("List", "User");
            }
            else
            {
                return View();
            }
        }
    }
}
