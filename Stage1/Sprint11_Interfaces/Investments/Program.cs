using System;

namespace Investments
{
    class Program
    {
        static void Main(string[] args)
        {
            Annuity ann = new Annuity();
            Stocks sto = new Stocks();
            Bonds bond = new Bonds();


            ann.Buy(1000.00);
            Console.WriteLine(ann.ToString());
            ann.Sell(200.00);
            Console.WriteLine(ann.ToString());
            ann.Earn(20.00);
            Console.WriteLine(ann.ToString());
            Console.WriteLine("");
            Console.WriteLine("");


            sto.Buy(5000.00);
            Console.WriteLine(sto.ToString());
            sto.Sell(1500.00);
            Console.WriteLine(sto.ToString());
            sto.Earn(2000.00);
            Console.WriteLine(sto.ToString());
            Console.WriteLine("");
            Console.WriteLine("");

            bond.Buy(3500.00);
            Console.WriteLine(bond.ToString());
            bond.Sell(200.00);
            Console.WriteLine(bond.ToString());
            bond.Earn(150.00);
            Console.WriteLine(bond.ToString());


            Console.WriteLine("");
            Console.WriteLine("");
            double port = ann.GetShares + sto.GetShares + bond.GetShares;

            Console.WriteLine("Your portfolio is worth $ " + port);
        }
    }
}
