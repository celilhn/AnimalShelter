using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Application.Filters;

namespace AnimalShelter.Controllers
{
    [AdminAuthorize()]
    public class PetTypeController : Controller
    {
        private readonly IPetTypeService petTypeService;
        public PetTypeController(IPetTypeService petTypeService)
        {
            this.petTypeService = petTypeService;
        }

        [HttpGet]
        public IActionResult List()
        {
            List<PetType> petTypes = new List<PetType>();
            try
            {
                petTypes = petTypeService.GetPetTypes(-1);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(petTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PetType petType = new PetType();
            return View(petType);
        }

        [HttpPost]
        public IActionResult Create(PetType petType)
        {
            try
            {
                if (petType.Name != null)
                {
                    petType = petTypeService.SavePetType(petType);
                }
                if (petType.ID == 0)
                {
                    ViewBag.resultMessage = "Kayıt Başarısız!!";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (petType.ID > 0)
            {
                return RedirectToAction("List", "PetType");
            }
            else
            {
                return View(petType);
            }
        }

        [HttpGet]
        public IActionResult Update(int ID)
        {
            PetType petType = null;
            try
            {
                if (ID > 0)
                {
                    petType = petTypeService.GetPetType(ID);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (petType != null)
            {
                return View(petType);
            }
            else
            {
                return RedirectToAction("NonFound", "Home");
            }
        }

        [HttpPost]
        public IActionResult Update(PetType petType)
        {
            try
            {
                if (petType.ID > 0)
                {
                    petType = petTypeService.SavePetType(petType);
                }
                if (petType.ID == 0)
                {
                    ViewBag.resultMessage = "Güncelleme Başarısız!!";
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (petType.ID > 0)
            {
                return RedirectToAction("List", "Role");
            }
            else
            {
                return View(petType);
            }
        }
    }
}
