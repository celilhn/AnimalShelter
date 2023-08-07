using Domain.Models;
using static Domain.Constants.Constants;

namespace Application.Interfaces
{
    public interface IPetService
    {
        public Pet GetPet(int ID);
        public List<Pet> GetPets(int status);
        public List<Pet> GetApprovedPets();
        public Pet SavePet(Pet pet);
    }
}
