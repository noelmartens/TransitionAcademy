using System;
using System.Collections.Generic;
using System.Text;

namespace Investments
{
    public class Bonds
    {
        private double shares;


        public double GetShares
        {
            get => shares;
        }
        public void Buy()
        {

        }
        public void Sell()
        {

        }
        public void Earn()
        {

        }
        public double Buy(double pShares)
        {
            Console.WriteLine("Purchasing Bonds at $" + pShares);
            return shares += pShares;

        }

        public double Sell(double pShares)
        {
            Console.WriteLine("Selling Bonds at $" + pShares);
            return shares -= pShares;
        }

        public double Earn(double pInt)
        {
            Console.WriteLine("Earning on Bonds $" + pInt);
            return shares += pInt;
        }

        public override string ToString()
        {
            return ("Your Bonds are worth $" + shares);
        }
    }
}