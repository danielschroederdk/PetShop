using System;
namespace PetShopApp.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + "(ID: " + Id + ")";
        }
    }
}
