using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ContactSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = ReadContacts();
            var businesses = ReadBusinesses();
            var links = ReadLinks();

            // add contacts to business
            foreach (var link in links)
            {

                var business = businesses.First(b => b.Id == link.BusinessId);
                var contact = contacts.First(c => c.Id == link.ContactId);
                business.Contacts.Add(contact);

            }

            //  find specific business
            //var Edgepulse =
            //    business.First(b => b.Name == "Edgepulse");
            //var Edgepulse =
            //    businessDictionary.First(b => b.Value.Contacts.V.ToUpper() == "EDGEPULSE");
            //var businesses = from b in businessDictionary.ConValues.First(
            //                      c in Contact )
            //                 select b;
            var gabieBusiness =
                businesses.Where(b => b.Contacts.Any(
                     c => c.FirstName == "Gabie" && c.LastName == "Boulder"));
            var contactMostBusiness =
               (from l in links
                group l by l.ContactId into contactGrp
                orderby contactGrp.Count() descending
                select contactGrp);

          
            foreach (var grp in contactMostBusiness)
            {
                Console.WriteLine(
                    "This contact is associated with the most businesses " + 
                    grp.Key + "  " + grp.Count());
                break;
            }
            //PrintContacts(Edgepulse.Contacts);
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