using System;
using System.Collections.Generic;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner CreateOwner(String firstName, String lastName, String address, String phoneNumber, String email);
        Owner findOwnerById(int id);
        Owner Delete(int ID);
        Owner updateOwner(Owner ownerUpdate);
        List<Owner> GetOwners();


    }
}