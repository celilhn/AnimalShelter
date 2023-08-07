using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserApplicationRepository userApplicationRepository;

        public UserApplicationService()
        {
        }

        public UserApplicationService(IUserApplicationRepository userApplicationRepository)
        {
            this.userApplicationRepository = userApplicationRepository;
        }

        public UserApplication GetUserApplication(int ID)
        {
            return userApplicationRepository.GetUserApplication(ID);
        }

        public UserApplication GetUserApplication(int ID, int userID)
        {
            return userApplicationRepository.GetUserApplication(ID, userID);
        }

        public List<UserApplication> GetUserApplications(ApplicationTypes applicationType, int status)
        {
            return userApplicationRepository.GetUserApplications(applicationType, status);
        }

        public List<UserApplication> GetUserApplications(int userID, int status)
        {
            return userApplicationRepository.GetUserApplications(userID, status);
        }

        public UserApplication SaveUserApplication(UserApplication userApplication)
        {
            if (userApplication.ID > 0)
            {
                userApplication.UpdateDate = DateTime.Now;
                userApplication = userApplicationRepository.UpdateUserApplication(userApplication);
            }
            else
            {
                userApplication = userApplicationRepository.AddUserApplication(userApplication);
            }
            return userApplication;
        }
    }
}
