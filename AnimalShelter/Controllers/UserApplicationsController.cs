using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using static Domain.Constants.Constants;
using System.Drawing;
using Application.Filters;
using Application.Extensions;

namespace AnimalShelter.Controllers
{
    public class UserApplicationsController : Controller
    {
        private readonly IUserApplicationService userApplicationService;
        private readonly IPetService petService;
        public UserApplicationsController(IUserApplicationService userApplicationService, IPetService petService)
        {
            this.userApplicationService = userApplicationService;
            this.petService = petService;
        }

        [HttpGet]
        [AdminAuthorize()]
        public IActionResult OwnerShipApplicationList()
        {
            List<UserApplication> userApplications = new List<UserApplication>();
            try
            {
                userApplications = userApplicationService.GetUserApplications(ApplicationTypes.Ownership, -1);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(userApplications);
        }

        [HttpGet]
        [AdminAuthorize()]
        public IActionResult AcceptanceApplicationList()
        {
            List<UserApplication> userApplications = new List<UserApplication>();
            try
            {
                userApplications = userApplicationService.GetUserApplications(ApplicationTypes.Acceptance, -1);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return View(userApplications);
        }

        [AdminAuthorize()]
        public ActionResult ReplyApplication(int ID, ApplicationStatuses applicationStatus, ApplicationTypes applicationType)
        {
            UserApplication userApplication = null;
            Pet pet = null;
            try
            {
                userApplication = userApplicationService.GetUserApplication(ID);
                userApplication.ApplicationStatus = applicationStatus;
                userApplicationService.SaveUserApplication(userApplication);
                if (applicationType == ApplicationTypes.Acceptance && applicationStatus == ApplicationStatuses.Approved)
                {
                    pet = petService.GetPet(userApplication.PetID);
                    pet.Approved = 2;
                    pet.OwnerID = userApplication.UserID;
                    pet = petService.SavePet(pet);
                }
                else if (applicationType == ApplicationTypes.Ownership && applicationStatus == ApplicationStatuses.Approved)
                {
                    pet = petService.GetPet(userApplication.PetID);
                    pet.Approved = 1;
                    pet.OwnerID = userApplication.UserID;
                    pet = petService.SavePet(pet);
                }
                TempData["AlertType"] = ActionTypes.Update.ToString();
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            if(applicationType == ApplicationTypes.Acceptance)
            {
                return RedirectToAction("AcceptanceApplicationList", "UserApplications");
            }
            else
            {
                return RedirectToAction("OwnerShipApplicationList", "UserApplications");
            }
        }

        [Authorize()]
        public ActionResult UserApplications()
        {
            List<UserApplication> userApplications = null;
            User user = null;
            try
            {
                user = HttpContext.Session.GetObjectFromJson<User>("User");
                userApplications = userApplicationService.GetUserApplications(user.ID, (int)StatusCodes.Aktif);
            }
            catch (Exception ex)
            {
                TempData["AlertType"] = ActionTypes.Error.ToString();
                Console.WriteLine(ex);
            }
            return View(userApplications);
        }
    }
}
