using System;
using System.Collections.Generic;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet ReadByID(int ID);
        IEnumerable<Pet> ReadAll();
        Pet Update(Pet petUpdate);
        Pet Delete(int ID);
    }

    
}
