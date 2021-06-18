using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace JSONParser
{
    class Program
    {

        static void Main(string[] args)
        {

            jsonParser();
            xmlParser();

        }


        static void jsonParser()
        {
            var text =
                 File.ReadAllText("G:\\Class\\Stage2\\Console-CSV-Parser\\Data Files\\Contacts.JSON");
            var contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<Contact[]>(text);

            foreach (var contact in contacts)
            {
                try
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");

                }
                catch (Exception e)
                {
                    Console.WriteLine("can't parse the line " + e);

                }

            }
        }


        static void xmlParser()
        {
            string path =
             @"G:\\Class\\Stage2\\Console-CSV-Parser\\Data Files\\Contacts.XML";
            int counter = 0;

            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to be deserialized.
            XmlSerializer serializer = new XmlSerializer(typeof(Contact));

            // If the XML document has been altered with unknown
            // nodes or attributes, handles them with the
            // UnknownNode and UnknownAttribute events.
            try
            {
                XmlNodeEventHandler serializer_UnknownNode = null;
                XmlAttributeEventHandler serializer_UnknownAttribute = null;

                serializer.UnknownNode +=
                    new XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute +=
                    new XmlAttributeEventHandler(serializer_UnknownAttribute);
                Contact contact = new Contact();


                // open the file for input
                File.OpenRead(path);
                // Read the file and display it line by line.
                System.IO.StreamReader sr =
                    new System.IO.StreamReader(path);
          
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    contact = (Contact)serializer.Deserialize(sr);
                    
                   // Console.WriteLine($"{FirstName} {LastName}");

                    counter++;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("can't parse the line " + e);

            }
        }

        protected void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }
        protected void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
            attr.Name + "='" + attr.Value + "'");
        }
    }
}
