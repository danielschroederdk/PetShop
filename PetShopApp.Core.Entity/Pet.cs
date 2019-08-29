using System;

namespace PetShopApp.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public String Color { get; set; }
        public Owner Owner { get; set; }
        public double Price { get; set; }

    }
}
