using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
      

        public Owner Create(Owner owner)
        {
            owner.Id = PetDB.OwnerId++;
            PetDB.Owners.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            var toRemove = ReadByID(id);
            RemoveOwnerFromPet(id);
            PetDB.Owners.Remove(toRemove);
            return toRemove;
        }

        private static void RemoveOwnerFromPet(int id)
        {
            var listOfPets = PetDB.Pets;
            
            foreach (var pet in listOfPets.Where(pet => pet.Owner.Id == id))
            {
                pet.Owner = null;
            }
        }

        public IEnumerable<Owner> ReadAll()
        {
            return PetDB.Owners;
        }

        public Owner ReadByID(int id)
        {
            var listOfOwners = ReadAll();
            return listOfOwners.FirstOrDefault(owner => owner.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
