using System;
using System.Collections.Generic;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner ReadByID(int ID);
        IEnumerable<Owner> ReadAll();
        Owner Update(Owner ownerUpdate);
        Owner Delete(int ID);
    }
}
