using System;
using System.Collections.Generic;
using System.Text;

namespace Roster_mvc
{
    class Roster_view
    {
        public string SendWelcome()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("Welcome to your Class Roster...(press <enter> to continue type N to quit)?: ");
            return Console.ReadLine();
        }

        public string SendMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Add Instructor");
            Console.WriteLine("\t2 - Add Student");
            Console.WriteLine("\t3 - Display Roster");
            Console.WriteLine("\t4 - quit");
            Console.WriteLine("");
            Console.Write("Your option? ");
            return Console.ReadLine().ToUpper();
        }

        public string GetInstructorFname()
        {
            Console.WriteLine("");
            Console.Write("Enter the Instructors First Name.....: ");
            return Console.ReadLine();

        }

        public string GetInstructorLname()
        {
            Console.Write("Enter the Instructors Last Name......: ");
            return Console.ReadLine();

        }

        public string GetInstructorEmail()
        {
            Console.Write("Enter the Instructors Email Address..: ");
            return Console.ReadLine();

        }

        public string GetStudentFname()
        {
            Console.WriteLine("");
            Console.Write("Enter the Student's First Name.....: ");
            return Console.ReadLine();
        }

        public string GetStudentLname()
        {
            Console.Write("Enter the Student's Last Name......: ");
            return Console.ReadLine();

        }

        public string GetStudentRank()
        {
            Console.Write("Enter the Student's grade level....: ");
            return Console.ReadLine();

        }
        public void ShowError(string result)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(result);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public void PrintClass(Instructor ins, List<Student> myClass)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(ins);
            foreach (Student x in myClass)
            {
                Console.WriteLine(x);
            }
        }
    }
}
