using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;
        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public List<Pet> GetApprovedPets()
        {
            return petRepository.GetApprovedPets();
        }

        public Pet GetPet(int ID)
        {
            return petRepository.GetPet(ID);
        }

        public List<Pet> GetPets(int status)
        {
            return petRepository.GetPets(status);
        }

        public Pet SavePet(Pet pet)
        {
            if (pet.ID > 0)
            {
                pet.UpdateDate = DateTime.Now;
                pet = petRepository.UpdatePet(pet);
            }
            else
            {
                pet = petRepository.AddPet(pet);
            }
            return pet;
        }
    }
}
