using Domain.Models;
using static Domain.Constants.Constants;

namespace Domain.Interfaces
{
    public interface IUserApplicationRepository
    {
        public UserApplication GetUserApplication(int ID);
        public UserApplication GetUserApplication(int ID, int userID);
        public List<UserApplication> GetUserApplications(ApplicationTypes applicationType, int status);
        public List<UserApplication> GetUserApplications(int userID, int status);
        public UserApplication AddUserApplication(UserApplication userApplication);
        public UserApplication UpdateUserApplication(UserApplication userApplication);
    }
}
