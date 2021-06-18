using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace XMLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            xmlParser();
        }


        static void xmlParser()
        {
            string path =
             "G:/Class/Stage2/Console-CSV-Parser/Data Files/Contacts.XML";

            try
            {
                // Create an instance of the XmlSerializer specifying type.
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));

                // Create a filestream to read the file.
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {

                    List<Contact> result = (List<Contact>)serializer.Deserialize(fs);
                    foreach (var contact in result)
                    {
                        // Write out the properties of the object.
                        Console.WriteLine($"name: {contact.firstName} {contact.lastName}  " +
                            $"IP: {contact.IpAddress}  skill: {contact.Skill}");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("can't parse the line " + e);

            }
        }
    }
}