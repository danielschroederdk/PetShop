using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner CreateOwner(string firstName, string lastName, string address, string phoneNumber, string email)
        {
            var newOwner = new Owner()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber
            };
            if (string.IsNullOrEmpty(newOwner.FirstName))
            {
                throw new InvalidDataException("Owner has to have a firstname");
            }
            _ownerRepository.Create(newOwner);
            return newOwner;
        }

        public Owner Delete(int id)
        {
            return findOwnerById(id) == null
                ? throw new InvalidDataException("Owner not found or already deleted")
                : _ownerRepository.Delete(id);
        }

        public Owner findOwnerById(int id)
        {
            
            return _ownerRepository.ReadByID(id) == null
                ? throw new InvalidDataException("Owner not found")
                : _ownerRepository.ReadByID(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        public Owner updateOwner(Owner ownerUpdate)
        {
            return _ownerRepository.Update(ownerUpdate);
        }
    }
}
