using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using static Domain.Constants.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Filters;

namespace AnimalShelter.Controllers
{
    [AdminAuthorize()]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public UserController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        [HttpGet]
        public IActionResult List()
        {
            List<User> users = new List<User>();
            try
            {
                users = userService.GetUsers(-1);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult Update(int ID)
        {
            User user = null;
            try
            {
                if (ID > 0)
                {
                    user = userService.GetUser(ID);
                }
                this.SetRoleSelectList();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("NonFound", "Home");
            }
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            try
            {
                if (user.ID > 0)
                {
                    user = userService.SaveUser(user);
                }
                if (user.ID == 0)
                {
                    ViewBag.resultMessage = "Güncelleme Başarısız!!";
                }
                this.SetRoleSelectList();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (user.ID > 0)
            {
                return RedirectToAction("List", "User");
            }
            else
            {
                return View(user);
            }
        }

        private void SetRoleSelectList()
        {
            List<Role> roles = null;
            try
            {
                roles = roleService.GetRoles((int)StatusCodes.Aktif);
                ViewBag.Roles = new SelectList(roles, "ID", "Name");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
