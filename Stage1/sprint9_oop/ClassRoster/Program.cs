using System;
using System.Collections.Generic;

namespace ClassRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string classRank;
            Instructor ins = new Instructor();
            List<Student> myClass = new List<Student>();

            Boolean enterMore = true;

            /*
            Person t = new Person("Joe", "Teacher");
            Instructor x = new Instructor(t.FirstName, t.LastName, "joe.Teacher@teacher.com");
            Console.WriteLine(x.ToString());

            Person st = new Person("Sally", "Student");
            Student y = new Student(st.FirstName, st.LastName, "senior");
            Console.WriteLine(y.ToString());
            */
 
            while (enterMore)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\t1 - Add Instructor");
                Console.WriteLine("\t2 - Add Student");
                Console.WriteLine("\t3 - Display Roster");
                Console.WriteLine("\tq - quit");
                Console.WriteLine("");
                Console.Write("Your option? ");
                Console.WriteLine("");
                string op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine("Enter the Instructors First Name.....: ");
                        ins.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter the Instructors Last Name......: ");
                        ins.LastName = Console.ReadLine();
                        Console.WriteLine("Enter the Instructors Email Address..: ");
                        ins.EmailAddr = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("");
                        Console.Write("Enter the Students First Name..:");
                        firstName = Console.ReadLine();
                        Console.Write("Enter the Students Last Name...:");
                        lastName = Console.ReadLine();
                        Console.Write("Enter the Students Rank........:");
                        classRank = Console.ReadLine();
                        Student stu = new Student(firstName, lastName, classRank);
                        myClass.Add(stu);
                        break;

                    case "3":
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine(ins);
                        foreach (Student x in myClass)
                        {
                            Console.WriteLine(x);
                        }
                        break;

                    case "Q":
                        enterMore = false;
                        break;

                    default:
                        enterMore = false;
                        break;

                }

            }
        }
    }
}
