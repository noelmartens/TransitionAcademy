using System;
namespace Investments
{

    public class Annuity : IAnnuity
    {
        private double Shares;

        public double GetShares
        {
            get => Shares; 
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
            Console.WriteLine("Purchasing Annuity at $" + pShares);
            return Shares += pShares;

        }

        public double Sell(double pShares)
        {
            Console.WriteLine("Selling Annuity at $" + pShares);
            return Shares -= pShares;
        }

        public double Earn(double pInt)
        {
            Console.WriteLine("Earning on Annuity $" + pInt);
            return Shares += pInt;
        }

        public override string ToString()
        {
            return ("Your annuity is worth $" + Shares);
        }
    }
}
