using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.Static.Data;
using PetShopApp.Infrastructure.Static.Data.Repositories;

namespace PetShop
{
    public class Printer : IPrinter 
    {
        readonly IPetService _petService;
        readonly IOwnerService _ownerService;
           
        public Printer(IPetService petService, IOwnerService ownerService)
        {
            _petService = petService;
            _ownerService = ownerService;
        }

        public void menuChoice()
        {
            MenuType selectedSubMenu = displayMainMenu();
            while (selectedSubMenu != MenuType.Quit)
            {
                switch (selectedSubMenu)
                {
                    case MenuType.Create:
                        createPet();
                        break;
                    case MenuType.Remove:
                        deletePet();
                        break;
                    case MenuType.Update:
                        updatePet();
                        break;
                    case MenuType.Read:
                        printPets();
                        break;
                    case MenuType.Search:
                        printPetsByType((PetType)Enum.Parse(typeof(PetType), Question("Pet type: ")));
                        break;
                    case MenuType.Sortbyprice:
                        sortPetsByPrice();
                        break;
                    case MenuType.Fivecheapest:
                        fiveCheapest();
                        break;
                    case MenuType.Owner:
                        ownerMenu();
                        break;
                    case MenuType.Quit:
                        break;
                }
                Console.WriteLine("\n\nEnter to continue");
                Console.ReadLine();
                selectedSubMenu = displayMainMenu();
            }
            Console.WriteLine("Shutting down..");
        }

        private void sortPetsByPrice()
        {
            var listOfPets = _petService.GetPets();
            listOfPets.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
            
            foreach (var pet in listOfPets)
            {
                Console.WriteLine("Name: {0} (ID: {1}), Owner: {2}, Price: {3} ",pet.Name, pet.Id, pet.Owner, pet.Price);
            }

        }

        private void fiveCheapest()
        {
            var fiveList = _petService.GetPets().OrderBy(i => i.Price).Take(5);

            foreach (var pet in fiveList)
            {
                Console.WriteLine("Name: {0} (ID: {1}), Owner: {2}, Price: {3} ",pet.Name, pet.Id, pet.Owner, pet.Price);
            }

        }

        private String printPets()
        {
            var listOfPets = _petService.GetPets();
            
            foreach (var pet in listOfPets)
            {
                Console.WriteLine("Name: {0} (ID: {1}), Owner: {2}, Price: {3} ",pet.Name, pet.Id, pet.Owner, pet.Price);
            }
            return null;
        }

        //Pet 
        private Pet createPet()
        {
            var name = Question("Name: ");
            var petType = (PetType)Enum.Parse(typeof(PetType), Question("Pet type: "));
            var birthDate = DateTime.Parse(Question("Birthday (DD-MM-YY): "));
            var soldDate = DateTime.Parse(Question("Sold (DD-MM-YY): "));
            var color = Question("Color: ");
            var ownerId = Question("Owner (ID): ");
            var owner = _ownerService.findOwnerById(int.Parse(ownerId));
            var price = int.Parse(Question("Price: "));
            
            Console.WriteLine("\nPet created with following:\nName: {0}, Pet Type: {1}, Birthdate: {2}, Sold: {3}, Color: {4}, Owner: {5}, Price: {6}",name, petType, birthDate, soldDate, color, owner, price);
            return _petService.CreatePet(name, petType, birthDate, soldDate, color, owner, price);

        }

        private Pet deletePet()
        {
            var id = int.Parse(Question("ID of pet: "));
            var toRemove = _petService.Delete(id);
            return toRemove;
        }

        private Pet updatePet()
        {
            var id = int.Parse(Question("ID of pet: "));
            Pet toUpdate = _petService.findPetById(id);
            toUpdate.Name = Question("Name (" + toUpdate.Name + "): ");
            toUpdate.Type = (PetType)Enum.Parse(typeof(PetType), Question("Pet type: "));
            toUpdate.BirthDate = DateTime.Parse(Question("Birthday: "));
            toUpdate.SoldDate = DateTime.Parse(Question("Sold (Date): "));
            toUpdate.Color = Question("Color: ");
            var ownerId = Question("Owner (ID): ");
            toUpdate.Owner = _ownerService.findOwnerById(int.Parse(ownerId));
            toUpdate.Price = int.Parse(Question("Price: "));
            return toUpdate;
        }

        //Owner
        private Owner createOwner()
        {
            var firstName = Question("Firstname: ");
            var lastName = Question("Lastname: ");
            var address = Question("Address: ");
            var phoneNumber = Question("Phone number: ");
            var email = Question("Email: ");
            return _ownerService.CreateOwner(firstName, lastName, address, phoneNumber, email);
        }

        private Owner deleteOwner()
        {
            var id = int.Parse(Question("ID of owner: "));
            var toRemove = _ownerService.Delete(id);
            return toRemove;
        }

        private Owner updateOwner()
        {
            var id = int.Parse(Question("ID of owner: "));
            var toUpdate = _ownerService.findOwnerById(id);
            toUpdate.FirstName = Question("Firstname: ");
            toUpdate.LastName = Question("Lastname: ");
            toUpdate.Address = Question("Address: ");
            toUpdate.PhoneNumber = Question("Phone number: ");
            toUpdate.Email = Question("Email: ");
            return toUpdate;

        }

        private String printOwners()
        {
            var listOfOwners = _ownerService.GetOwners();

            foreach (var owner in listOfOwners)
            {
                Console.WriteLine("Name: {0} {1}, ID: {2}, Address: {3}, Phone: {4}, Email: {5} ", owner.FirstName,
                    owner.LastName, owner.Id, owner.Address, owner.PhoneNumber, owner.Email);
  
            }
            return null;
        }

        private String printPetsByType(PetType petType)
        {
            var listOfPets = _petService.GetPets();

            foreach (var pet in listOfPets.Where(pet => pet.Type == petType))
            {
                Console.WriteLine("Name: {0}, ID: {1}, Owner: {2}",pet.Name, pet.Id, pet.Owner);
               
            }
            return null;
        }

        private String Question(String question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        private void ownerMenu()
        {
            var selected = ownerMenuChoice();

            while (selected != 5)
            {
                switch (selected)
                {
                    case 1:
                        createOwner();
                        break;
                    case 2:
                        deleteOwner();
                        break;
                    case 3:
                        updateOwner();
                        break;
                    case 4:
                        printOwners();
                        break;
                    case 5:
                        menuChoice();
                        break;
                   
                }
                
                Console.WriteLine("\n\nEnter to continue");
                Console.ReadLine();
                selected = ownerMenuChoice();
            }
         

        }

        private int ownerMenuChoice()
        {
            Console.Clear();
            Console.WriteLine("OWNER OPTIONS\n");
            Console.WriteLine(" 1. Create owner");
            Console.WriteLine(" 2. Remove owner");
            Console.WriteLine(" 3. Update owner");
            Console.WriteLine(" 4. List owners");
            Console.WriteLine(" 5. Back to main");
            Console.WriteLine("");
            return int.Parse(Console.ReadLine());
        }

        

        private static MenuType displayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU\n");
            Console.WriteLine(" 1. Create pet in system");
            Console.WriteLine(" 2. Remove pet from system");
            Console.WriteLine(" 3. Update pet information");
            Console.WriteLine(" 4. Pet list");
            Console.WriteLine(" 5. Pet list by type");
            Console.WriteLine(" 6. Pets sorted by price");
            Console.WriteLine(" 7. Five cheapest");
            Console.WriteLine(" 8. Owner-menu");
            Console.WriteLine(" 9. Quit");
            Console.WriteLine();
            String selectedSubMenu = Console.ReadLine();
            return (MenuType)Enum.Parse(typeof(MenuType), selectedSubMenu);
        }


        public void Run()
        {
            PetDB.InitData();
            menuChoice();
        }
    }
}
