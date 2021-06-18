using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections;

namespace JSONParser
{
    class Program
    {
        static void Main(string[] args)
        {

            jsonParserForLoop();
            Console.WriteLine("=========================================");
            jsonParserWhileLoop();
            Console.WriteLine("=========================================");
            jsonParserDoWhileLoop();
            Console.WriteLine("=========================================");
            jsonParserLinqLoop();

        }



        static void jsonParserForLoop()
        {
            var text =
                 File.ReadAllText("G:/Class/Stage2/Console-CSV-Parser/Data Files/ContactsWithHeight.JSON");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);
            Array.Sort(contacts, new PersonComparer());            
            int count = 0;
            for (int i = 0; i < contacts.Length; i++)
            {
                try
                {
                    Contact contact = contacts[i];
                    int result = Int32.Parse(contact.height);
                    if (result > 70)
                    {
                        count++;
                        Console.WriteLine($"{contact.FirstName} {contact.LastName}  {contact.height}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("can't parse the line " + e);

                }

            }
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("Rows found = " + count);
            Console.WriteLine("  ");
            Console.WriteLine("  ");
        }



        static void jsonParserWhileLoop()
        {
            var text =
                 File.ReadAllText("G:/Class/Stage2/Console-CSV-Parser/Data Files/ContactsWithHeight.JSON");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);
            Array.Sort(contacts, new PersonComparer());
            int i = 0;
            int count = 0;
            do
            {
                try
                {
                    Contact contact = contacts[i];
                    int result = Int32.Parse(contact.height);
                    if (result > 70)
                    {
                        count++;
                        Console.WriteLine($"{contact.FirstName} {contact.LastName}  {contact.height}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("can't parse the line " + e);

                }
                i++;
            } while (i < contacts.Length);
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("Rows found = " + count);
            Console.WriteLine("  ");
            Console.WriteLine("  ");
        }




        static void jsonParserDoWhileLoop()
        {
            var text =
                 File.ReadAllText("G:/Class/Stage2/Console-CSV-Parser/Data Files/ContactsWithHeight.JSON");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);
            Array.Sort(contacts, new PersonComparer());
            int i = 0;
            int count = 0;
            while (i < contacts.Length)
            {
                try
                {
                    Contact contact = contacts[i];
                    int result = Int32.Parse(contact.height);
                    if (result > 70)
                    {
                        count++;
                        Console.WriteLine($"{contact.FirstName} {contact.LastName}  {contact.height}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("can't parse the line " + e);

                }
                i++;
            }
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("Rows found = " + count);
            Console.WriteLine("  ");
            Console.WriteLine("  ");
        }



        static void jsonParserLinqLoop()
        {
            var text =
                 File.ReadAllText("G:/Class/Stage2/Console-CSV-Parser/Data Files/ContactsWithHeight.JSON");
            var contacts = JsonConvert.DeserializeObject<Contact[]>(text);
            var filteredList = from contact in contacts
                               where Int32.Parse(contact.height) < 68
                               orderby contact.LastName
                               select contact ;
            
            int count = 0;
            foreach (var contact in filteredList)
            {
                try
                {
                    count++;
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}  {contact.height}");

                }
                catch (Exception e)
                {
                    Console.WriteLine("can't parse the line " + e);

                }
            }
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("Rows found = " + count);
            Console.WriteLine("  ");
            Console.WriteLine("  ");
        }



        class PersonComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(((Contact)x).LastName, ((Contact)y).LastName);

            }
        }
    }
}