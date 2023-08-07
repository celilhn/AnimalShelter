using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeRepository petTypeRepository;
        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            this.petTypeRepository = petTypeRepository;
        }

        public PetType GetPetType(int ID)
        {
            return petTypeRepository.GetPetType(ID);
        }

        public List<PetType> GetPetTypes(int status)
        {
            return petTypeRepository.GetPetTypes(status);
        }

        public PetType SavePetType(PetType petType)
        {
            if (petType.ID > 0)
            {
                petType.UpdateDate = DateTime.Now;
                petType = petTypeRepository.UpdatePetType(petType);
            }
            else
            {
                petType = petTypeRepository.AddPetType(petType);
            }
            return petType;
        }
    }
}
