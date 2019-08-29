using System;
using System.Collections.Generic;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
        Pet CreatePet(String name, PetType type, DateTime birthDate, DateTime soldDate, String color, Owner owner, double price);
        Pet findPetById(int id);
        Pet Delete(int id);
        Pet updatePet(Pet petUpdate);

    }


}
