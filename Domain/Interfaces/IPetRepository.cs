using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPetRepository
    {
        public Pet GetPet(int ID);
        public List<Pet> GetPets(int status);
        public List<Pet> GetApprovedPets();
        public Pet AddPet(Pet pet);
        public Pet UpdatePet(Pet pet);
    }
}
