using System;
using System.Collections.Generic;
using System.Text;

namespace Music-mvc
{
    class Music_view
    {
        public string SendWelcome()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("Welcome to your Music Collection...(press <enter> to continue type N to quit)?: ");
            return Console.ReadLine();
        }

        public string SendMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Add an Album to your Collection");
            Console.WriteLine("\t2 - Display Your Collection");
            Console.WriteLine("\t3 - quit");
            Console.WriteLine("");
            Console.Write("Your option? ");
            string op = Console.ReadLine().ToUpper();
            return Console.ReadLine().ToUpper();
        }
    }
}
