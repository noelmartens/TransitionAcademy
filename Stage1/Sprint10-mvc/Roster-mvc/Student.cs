using System;
using System.Collections.Generic;
using System.Text;

namespace Roster_mvc
{
    class Student : Person
    {
        public string Rank { get; set; }

        public Student() : base()
        {
            Rank = "";
        }

        public Student(string pFirstName, string pLastName, string pRank) : base(pFirstName, pLastName)
        {
            Rank = pRank;
        }

        public override string ToString()
        {
            return "student......" + FirstName + " " + LastName + " " + Rank;
        }

    }
}
