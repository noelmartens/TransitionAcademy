using System;
using System.Xml;
using System.Xml.Serialization;

namespace XMLParser
{

     public class Contact
    {
        public int Id { get; set; }
        [XmlElement("FirstName")]
        public string firstName { get; set; }
        [XmlElement("LastName")]
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string IpAddress { get; set; }
        public string Skill { get; set; }
        public Guid Guid { get; set; }

    }
}