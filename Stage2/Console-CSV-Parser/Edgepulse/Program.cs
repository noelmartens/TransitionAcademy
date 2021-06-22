using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;


namespace EdgepulseExercise
{
    class Program
    {
        static void Main()
        {

            var contactDictionary = BuildContactDictionary();
            var businessDictionary = BuildBusinessDictionary();
            var links = ReadLinks();

            // add contacts to businesses
            foreach (var link in links)
            {

                var business = businessDictionary[link.BusinessId];
                var contact = contactDictionary[link.ContactId];
                business.Contacts.Add(contact);

            }

            //  find specific business
            //var Edgepulse =
            //    businessDictionary.First(b => b.Value.Name == "Edgepulse")
            var Edgepulse =
                businessDictionary.First(b => b.Value.Name.ToUpper() == "EDGEPULSE");
            PrintContacts(Edgepulse.Value.Contacts);
            Console.WriteLine(" ");
            Console.WriteLine(" ");

        }


        static Dictionary<int, Contact> BuildContactDictionary()
        {
            var contactDictionary = new Dictionary<int, Contact>();
            var contacts = ReadContacts();
            foreach (var contact in contacts)
            {
                contactDictionary.Add(contact.Id, contact);
            }
            return contactDictionary;
        }



        static Dictionary<int, Business> BuildBusinessDictionary()
        {
            var businessDictionary = new Dictionary<int, Business>();
            var businesses = ReadBusinesses();
            foreach (var business in businesses)
            {
                businessDictionary.Add(business.Id, business);

            }

            return businessDictionary;
        }


        static Contact[] ReadContacts()
        {
            using var reader = new StreamReader("G:/Class/Stage2/Console-CSV-Parser/Data Files/Contacts.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var contacts = csv.GetRecords<Contact>().ToArray();
            return contacts;
        }




        static Business[] ReadBusinesses()
        {
            using var reader = new StreamReader("G:/Class/Stage2/Console-CSV-Parser/Data Files/Business.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var businesses = csv.GetRecords<Business>().ToArray();
            return businesses;
        }



        static ContactToBusinessLink[] ReadLinks()
        {
            using var reader = new StreamReader("G:/Class/Stage2/Console-CSV-Parser/Data Files/ContactToBusiness.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var links = csv.GetRecords<ContactToBusinessLink>().ToArray();
            return links;
        }

        public static void PrintContacts(List<Contact> contacts)
        {
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }

    }
}