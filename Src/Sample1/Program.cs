using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection string can be stored in the connectionStrings config section
            using (var documentStore = new DocumentStore { Url = "http://localhost:55786/", DefaultDatabase = "Sample-1" }.Initialize())
            {
                // Create
                using (var session = documentStore.OpenSession())
                {
                    var person = new Person
                    {
                        FirstName = "Yunus Emre",
                        LastName = "Keskin",
                        EmailAddress = "keskin@yunusemre.com",
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Line1 = "321 Anywhere", 
                                City = "Istanbul", 
                                State = "TC", 
                                Zip = "54300"
                            }
                        },
                        PhoneNumbers = new List<PhoneNumber> 
                        {
                            new PhoneNumber
                            {
                                PhoneType="Mobile",
                                Number="000000"
                            }
                        }
                    };
                    session.Store(person);
                    session.SaveChanges();
                }

                // Update
                using (var session = documentStore.OpenSession())
                {
                    // Retrieve
                    var person = session.Load<Person>("people/1");

                    person.PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber{ PhoneType = "Mobile", Number = "000-000-0000" }
                    };

                    session.SaveChanges();
                }

                // Query
                using (var session = documentStore.OpenSession())
                {
                    var people = session.Query<Person>()
                        .Where(x => x.Addresses.Any(a => a.City == "Istanbul"));

                    foreach (var person in people)
                        Console.WriteLine(person.FirstName + " " + person.LastName);
                }

                // Delete
                using (var session = documentStore.OpenSession())
                {
                    var person = session.Load<Person>("people/1");

                    session.Delete(person);
                    session.SaveChanges();
                }
            }

            Console.ReadLine();
        }
    }
}
