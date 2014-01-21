using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1
{
    public class Person
    {
        public Person()
        {
            Addresses = new List<Address>();
            PhoneNumbers = new List<PhoneNumber>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<PhoneNumber> PhoneNumbers { get; set; }
    }

    public class PhoneNumber
    {
        public string PhoneType { get; set; }
        public string Number { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
