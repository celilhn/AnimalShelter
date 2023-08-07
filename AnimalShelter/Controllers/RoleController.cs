using Application.Filters;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AnimalShelter.Controllers
{
    [AdminAuthorize()]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Role> roles = new List<Role>();
            try
            {
                roles = roleService.GetRoles(-1);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Role role = new Role();
			return View(role);
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            try
            {
                if(role.Name != null)
                {
                    role = roleService.SaveRole(role);
                }
                if(role.ID == 0)
                {
                    ViewBag.resultMessage = "Kayıt Başarısız!!";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if(role.ID > 0)
            {
                return RedirectToAction("List","Role");
            }
            else
            {
                return View(role);
            }
        }

        [HttpGet]
        public IActionResult Update(int ID)
        {
            Role role = null;
            try
            {
                if(ID > 0)
                {
                    role = roleService.GetRole(ID);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if(role != null)
            {
                return View(role);
            }
            else
            {
                return RedirectToAction("NonFound", "Home");
            }
        }

        [HttpPost]
        public IActionResult Update(Role role)
        {
            try
            {
                if (role.ID > 0)
                {
                    role = roleService.SaveRole(role);
                }
                if (role.ID == 0)
                {
                    ViewBag.resultMessage = "Güncelleme Başarısız!!";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (role.ID > 0)
            {
                return RedirectToAction("List", "Role");
            }
            else
            {
                return View(role);
            }
        }

    }
}
