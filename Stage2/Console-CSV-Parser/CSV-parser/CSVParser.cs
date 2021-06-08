using System;
using System.IO;

namespace CSV_parser
{
    class CSVParser
    {
        static void Main(string[] args)
        {

            var lines =
                File.ReadAllLines("G:\\Class\\Stage2\\Console-CSV-Parser\\Data Files\\Contacts.csv");

            foreach (var line in lines)
            {
                var splits = line.Split(',');

                try
                {
                    Console.WriteLine(splits[1] + " " + splits[2]);

                }
                catch (Exception e)
                {
                    Console.WriteLine("can't parse the line " + e);

                }

            }
        }
    }
}