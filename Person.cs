using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Person()
        {

        }

        public Person(string name, string address, string telephone, string email)
        {
            this.Address = address;
            this.Name = name;
            this.Email = email;
            this.Telephone = telephone;
        }

    }
}
