using Domain.Models;

namespace Application.Interfaces
{
    public interface IPetTypeService
    {
        public PetType GetPetType(int ID);
        public List<PetType> GetPetTypes(int status);
        public PetType SavePetType(PetType petType);
    }
}
