using System;
using System.Collections.Generic;
using System.Text;

namespace Roster_mvc
{
    class Instructor : Person
    {
        public string EmailAddr { get; set; }

        public Instructor() : base ()
        {
            EmailAddr = "";
        }

        public Instructor(string pFirstName, string pLastName, string pEmailAddr) : base(pFirstName, pLastName)
        {
            EmailAddr = pEmailAddr;
        }

        public override string ToString()
        {
            return "Instructor..." + FirstName + " " + LastName + " " + EmailAddr;
        }

    }
}
