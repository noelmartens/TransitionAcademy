using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRoster
{

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
 

        public Person()
        {
            FirstName = "";
            LastName = "";
        }

        public Person(string pfirstName, string plastName)
        {
            FirstName = pfirstName;
            LastName = plastName;
        }

        public override string ToString()
        {
            return "person......." + FirstName + " " + LastName;
        }

    }

}

