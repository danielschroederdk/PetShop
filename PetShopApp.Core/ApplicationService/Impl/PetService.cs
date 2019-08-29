using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;
        

        public PetService(IPetRepository petRepository) {
            _petRepository = petRepository;
            
        }

        public Pet CreatePet(string name, PetType type, DateTime birthDate, DateTime soldDate, string color, Owner owner, double price)
        {
            var newPet = new Pet()
            {
                Name = name,
                Type = type,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                Owner = owner,
                Price = price
            };
            
            if (string.IsNullOrEmpty(newPet.Name))
            {
                throw new InvalidDataException("Pet has to have a firstname");
            }
            
            _petRepository.Create(newPet);
            return newPet;
        }

        public Pet Delete(int id)
        {
            return findPetById(id) == null
                ? throw new InvalidDataException("Pet not found or already deleted")
                : _petRepository.Delete(id);
        }

        public Pet findPetById(int id)
        {
            return _petRepository.ReadByID(id) == null
                ? throw new InvalidDataException("Pet not found or already deleted")
                : _petRepository.ReadByID(id);

        }

      
        public List<Pet> GetPets()
        {
            return _petRepository.ReadAll().ToList();
        }

        public Pet updatePet(Pet petUpdate)
        {
            return _petRepository.Update(petUpdate);
        }
    }
}
