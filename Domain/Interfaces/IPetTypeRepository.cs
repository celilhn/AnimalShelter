using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPetTypeRepository
    {
        public PetType GetPetType(int ID);
        public List<PetType> GetPetTypes(int status);
        public PetType AddPetType(PetType petType);
        public PetType UpdatePetType(PetType petType);
    }
}
