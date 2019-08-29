using System;
using System.Collections.Generic;
using PetShopApp.Core.Entity;

namespace PetShopApp.Infrastructure.Static.Data
{
    public static class PetDB
    {
        public static List<Pet> Pets = new List<Pet>();
        public static int PetId = 1;

        public static List<Owner> Owners = new List<Owner>();
        public static int OwnerId = 1;
    
        public static void InitData()
        {

            var ownerTorben = new Owner()
            {
                FirstName = "Torben",
                LastName = "Jensen",
                Address = "Lallegade 2",
                Email = "mail@example.com",
                Id = OwnerId++,
                PhoneNumber = "12345678"
            };
            var dog = new Pet()
            {
                Name = "Sif",
                Type = PetType.Dog,
                Id = PetId++,
                Color = "Brown",
                BirthDate = DateTime.Now,
                Owner = ownerTorben,
                Price = 3500,
                SoldDate = DateTime.Now
            };

            var dog2 = new Pet()
            {
                Name = "Fiddo",
                Type = PetType.Dog,
                Id = PetId++,
                Color = "Brown",
                BirthDate = DateTime.Now,
                Owner = ownerTorben,
                Price = 1500,
                SoldDate = DateTime.Now
            };

            var reptile = new Pet()
            {
                Name = "Sicko",
                Type = PetType.Reptile,
                Id = PetId++,
                Color = "Brown",
                BirthDate = DateTime.Now,
                Owner = ownerTorben,
                Price = 2500,
                SoldDate = DateTime.Now
            };
            var reptile2 = new Pet()
            {
                Name = "Snickers",
                Type = PetType.Reptile,
                Id = PetId++,
                Color = "Brown",
                BirthDate = DateTime.Now,
                Owner = ownerTorben,
                Price = 10000,
                SoldDate = DateTime.Now
            };

            var reptile3 = new Pet()
            {
                Name = "Red Tail",
                Type = PetType.Reptile,
                Id = PetId++,
                Color = "Brown",
                BirthDate = DateTime.Now,
                Owner = ownerTorben,
                Price = 999,
                SoldDate = DateTime.Now
            };
            var reptile4 = new Pet()
            {
                Name = "Sling",
                Type = PetType.Reptile,
                Id = PetId++,
                Color = "Brown",
                BirthDate = DateTime.Now,
                Owner = ownerTorben,
                Price = 3500,
                SoldDate = DateTime.Now
            };

            var dog3 = new Pet()
            {
                Name = "Bjæf",
                Type = PetType.Dog,
                Id = PetId++,
                Color = "Brown",
                BirthDate = DateTime.Now,
                Owner = ownerTorben,
                Price = 4500,
                SoldDate = DateTime.Now
            };

            Owners.Add(ownerTorben);
            Pets.Add(dog);
            Pets.Add(dog2);
            Pets.Add(dog3);
            Pets.Add(reptile);
            Pets.Add(reptile2);
            Pets.Add(reptile3);
            Pets.Add(reptile4);



        }
    }


}

