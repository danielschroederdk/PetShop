using System;
using System.Collections.Generic;
using System.IO;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System.Linq;
namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class PetRepository : IPetRepository
    {

        public Pet Create(Pet pet)
        {
            pet.Id = PetDB.PetId++;
            PetDB.Pets.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            var toRemove = ReadByID(id);
            PetDB.Pets.Remove(toRemove);
            return toRemove;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return PetDB.Pets;
        }

        public Pet ReadByID(int id)
        {
            var listOfPets = ReadAll();
            return listOfPets.FirstOrDefault(pet => pet.Id == id);
        }

     
        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
