using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;


namespace CSVParserLinkContactWBusiness
{
    class Program
    {
        static void Main()
        {
            var contactDictionary = BuildContactDictionary();
            var businessDictionary = BuildBusinessDictionary();
            var links = ReadLinks();

            
             foreach (var link in links)
            {

                try
                {
                    var business = businessDictionary[link.BusinessId];
                    var contact = contactDictionary[link.ContactId];
                    business.Contacts.Add(contact);

                }
                catch (Exception e)
                {
                    Console.WriteLine("can't parse the line " + e);

                }

               
            }

           
            var businessWMoreThan1 = 0;
            var businessWMoreThan50 = 0;
            foreach (var b in businessDictionary.Values)
            {
                if (b.Contacts.Count > 0)
                {
                    businessWMoreThan1++;                  
                }
                if (b.Contacts.Count > 50)
                {
                    businessWMoreThan50++;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("business w more than 01  " + businessWMoreThan1);
            Console.WriteLine("business w more than 50  " + businessWMoreThan50);
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
    }
}