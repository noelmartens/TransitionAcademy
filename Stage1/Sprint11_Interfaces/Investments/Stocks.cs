using System;
using System.Collections.Generic;
using System.Text;

namespace Investments
{
    public class Stocks : IStock
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
            Console.WriteLine("Purchasing Stocks at $" + pShares);
            return shares += pShares;

        }

        public double Sell(double pShares)
        {
            Console.WriteLine("Selling Stocks at $" + pShares);
            return shares -= pShares;
        }

        public double Earn(double pInt)
        {
            Console.WriteLine("Earning on Stocks $" + pInt);
            return shares += pInt;
        }

        public override string ToString()
        {
            return ("Your Stocks are worth $" + shares);
        }
    }
}