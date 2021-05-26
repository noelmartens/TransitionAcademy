using System;
using System.Collections.Generic;
using System.Text;

namespace Music_mvc
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
            Console.WriteLine("\t1 - Add Albums to your Collection");
            Console.WriteLine("\t2 - Add Songs to your Collection");
            Console.WriteLine("\t3 - Display Your Collection");
            Console.WriteLine("\t4 - quit");
            Console.WriteLine("");
            Console.Write("Your option? ");
            return Console.ReadLine().ToUpper();
        }


        public string GetBandName()
        {
            Console.Write("Enter the Band's Name..........: ");
            return Console.ReadLine();

        }


        public string GetAlbumName()
        {
            Console.Write("Enter the Album Name...........: ");
            return Console.ReadLine();

        }


        public string GetSongTitle()
        {
            Console.Write("Enter the Song Title...........: ");
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

        public void PrintCollection(List<Music> myCollection)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            foreach (Music x in myCollection)
            {
                Console.WriteLine(x);
            }
        }
    }
}
