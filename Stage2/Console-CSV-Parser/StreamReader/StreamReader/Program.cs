using System;
using System.IO;

namespace CSV_parser
{
    internal class StreamReader
    {
        private static void Main(string[] args)
        {
            string path =
                @"G:\\Class\\Stage2\\Console-CSV-Parser\\Data Files\\Contacts.csv";
            int counter = 0;
            string line;

            try
            {
                // open the file for input
                File.OpenRead(path);
                // Read the file and display it line by line.
                System.IO.StreamReader file =
                    new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    var splits = line.Split(',');
                    Console.WriteLine(splits[1] + " " + splits[2]);
                    counter++;
                }

                file.Close();
                System.Console.WriteLine("There were {0} lines.", counter);

                // Suspend the screen.
                System.Console.ReadLine();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}