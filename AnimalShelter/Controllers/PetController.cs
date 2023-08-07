using Application.Filters;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Domain.Constants.Constants;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Application.Extensions;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AnimalShelter.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService petService;
        private readonly IPetTypeService petTypeService;
        private readonly IUserApplicationService userApplicationService;
        private readonly IWebHostEnvironment hostingEnvironment;
        public PetController(IPetService petService, IPetTypeService petTypeService, IUserApplicationService userApplicationService
            , IWebHostEnvironment hostingEnvironment)
        {
            this.petService = petService;
            this.petTypeService = petTypeService;
            this.userApplicationService = userApplicationService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [AdminAuthorize()]
        public IActionResult List()
        {
            List<Pet> pets = new List<Pet>();
            try
            {
                pets = petService.GetPets(-1);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(pets);
        }

        [HttpGet]
        [Authorize()]
        public IActionResult AdoptAnimal()
        {
            Pet pet = new Pet();
            try
            {
                this.SetPetTypeSelectList();
                ViewBag.Warning = null;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(pet);
        }

        [HttpPost]
        [Authorize()]
        public IActionResult AdoptAnimal(Pet pet, IFormFile Image)
        {
            UserApplication userApplication = null;
            User user = null;
            try
            {
                this.SetPetTypeSelectList();
                if (pet.Age <= 0)
                {
                    ViewBag.Warning = "Yaş 0'dan büyük olmalıdır.";
                }
                else if(Image == null)
                {
                    ViewBag.Warning = "Lütfen resim seçiniz.";
                }
                else
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                    fileName = (HttpContext.Session.GetObjectFromJson<User>("User")).ID.ToString() + "-" + fileName;
                    var filePath = Path.Combine(hostingEnvironment.WebRootPath, "Images", fileName);
                    filePath = filePath.Replace("\\wwwroot\\Images", "\\wwwroot\\Web\\assets\\Images");
                    using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        Image.CopyTo(stream);
                    }
                    pet.ImageUrl = fileName;
                    pet = petService.SavePet(pet);
                    user = HttpContext.Session.GetObjectFromJson<User>("User");
                    if(user != null)
                    {
                        userApplication = new UserApplication();
                        userApplication.UserID = user.ID;
                        userApplication.ApplicationType = ApplicationTypes.Ownership;
                        userApplication.PetID = pet.ID;
                        userApplicationService.SaveUserApplication(userApplication);
                    }
                    ViewBag.Warning = null;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(pet);
        }

        [HttpGet]
        public IActionResult PetDetail(int ID)
        {
            Pet pet = null;
            User user = null;
            UserApplication userApplication = null;
            try
            {
                pet = petService.GetPet(ID);
                user = HttpContext.Session.GetObjectFromJson<User>("User");
                if(user != null)
                {
                    userApplication = userApplicationService.GetUserApplication(ID, user.ID);
                    if (userApplication != null)
                    {
                        if (userApplication.ApplicationType == ApplicationTypes.Acceptance)
                        {
                            @ViewBag.Message = 1;
                        }
                        else
                        {
                            @ViewBag.Message = 2;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            if (pet != null)
            {
                return View(pet);
            }
            else
            {
                return RedirectToAction("NonFound", "Home");
            }
        }

        [Authorize()]
        public IActionResult AcceptanceApplication(int petID)
        {
            UserApplication userApplication = new UserApplication();
            User user = null;
            try
            {
                user = HttpContext.Session.GetObjectFromJson<User>("User");
                userApplication.UserID = user.ID;
                userApplication.PetID = petID;
                userApplication.ApplicationStatus = ApplicationStatuses.WaitingForApproval;
                userApplication.ApplicationType = ApplicationTypes.Acceptance;
                userApplicationService.SaveUserApplication(userApplication);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return RedirectToAction("PetDetail", "Pet", new { id = petID });

        }

        private void SetPetTypeSelectList()
        {
            List<PetType> petTypes = null;
            try
            {
                petTypes = petTypeService.GetPetTypes((int)Domain.Constants.Constants.StatusCodes.Aktif);
                ViewBag.PetTypes = new SelectList(petTypes, "ID", "Name");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
