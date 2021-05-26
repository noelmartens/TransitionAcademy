using System;
using System.Collections.Generic;

namespace MusicCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string bandName;
            string album;
            string genre;
            Boolean enterMore = true;
            List<Albums> myCollection = new List<Albums>();

            // Albums a = new Albums("Fleetwood Mac", "Rumours", "Rock");
            // Console.WriteLine(a.ToString());

            while (enterMore)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\t1 - Add an Album to your Collection");
                Console.WriteLine("\t2 - Display Your Collection");
                Console.WriteLine("\t3 - quit");
                Console.WriteLine("");
                Console.Write("Your option? ");
                Console.WriteLine("");
                string op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine("Enter the Band Name.....: ");
                        bandName = Console.ReadLine();
                        Console.WriteLine("Enter the Album Name.....: ");
                        album = Console.ReadLine();
                        Console.WriteLine("Enter the Genre..........: ");
                        genre = Console.ReadLine();
                        Albums alb = new Albums(bandName, album, genre);
                        myCollection.Add(alb);
                        break;


                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine("");
                        foreach (Albums x in myCollection)
                        {
                            Console.WriteLine(x);
                        }
                        break;


                    case "3":
                        enterMore = false;
                        break;

                }
            }
        }
    }
}
