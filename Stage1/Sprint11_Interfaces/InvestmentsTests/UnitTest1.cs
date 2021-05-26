using Microsoft.VisualStudio.TestTools.UnitTesting;
using Investments;

namespace InvestmentsTests
{
    [TestClass]
    public class UnitTest1
    {            // class + test  (naming convention)
        [TestMethod]
        public void buyAnnuity()
        {           // Method +  _  + scenario + _ + expected behavior   (naming convention)

            //Arrange
            double beginningBal = 1000.00;
            
            Annuity ann = new Annuity();

            //Act
            ann.Buy(beginningBal);
            double actualBal = ann.GetShares;

            // assert
            Assert.AreEqual(actualBal, 1000.00);

        }

        [TestMethod]
        public void sellAnnuity()
        {
            double beginningBal = 1000.00;
            double transactionAmount = 200.00;

            //Arrange
            Annuity ann = new Annuity();

            //Act
            ann.Buy(beginningBal);
            ann.Sell(transactionAmount);
            double actualBal = ann.GetShares;

            // assert
            Assert.AreEqual(actualBal, 800.00);

        }

        [TestMethod]
        public void EarnAnnuity()
        {
            double beginningBal = 800.00;
            double transactionAmount = 20.00;

            //Arrange
            Annuity ann = new Annuity();

            //Act
            ann.Buy(beginningBal);
            ann.Earn(transactionAmount);
            double actualBal = ann.GetShares;

            // assert
            Assert.AreEqual(actualBal, 820.00);

        }


        [TestMethod]
        public void buyStocks()
        {

            //Arrange
            double beginningBal = 5000.00;

            Stocks sto = new Stocks();

            //Act
            sto.Buy(beginningBal);
            double actualBal = sto.GetShares;

            // assert
            Assert.AreEqual(actualBal, 5000.00);

        }

        [TestMethod]
        public void sellStocks()
        {

            //Arrange
            double beginningBal = 5000.00;
            double transactionAmount = 1500.00;

            Stocks sto = new Stocks();

            //Act
            sto.Buy(beginningBal);
            sto.Sell(transactionAmount);
            double actualBal = sto.GetShares;

            // assert
            Assert.AreEqual(actualBal, 3500.00);

        }

        [TestMethod]
        public void EarnStocks()
        {

            //Arrange
            double beginningBal = 3500.00;
            double transactionAmount = 2000.00;

            Stocks sto = new Stocks();

            //Act
            sto.Buy(beginningBal);
            sto.Earn(transactionAmount);
            double actualBal = sto.GetShares;

            // assert
            Assert.AreEqual(actualBal, 5500.00);

        }

        [TestMethod]
        public void buyBonds()
        {

            //Arrange
            double beginningBal = 3500.00;

            Bonds bond = new Bonds();

            //Act
            bond.Buy(beginningBal);
            double actualBal = bond.GetShares;

            // assert
            Assert.AreEqual(actualBal, 3500.00);

        }

        [TestMethod]
        public void sellBonds()
        {

            //Arrange
            double beginningBal = 3500.00;
            double transactionAmount = 200.00;

            Bonds bond = new Bonds();

            //Act
            bond.Buy(beginningBal);
            bond.Sell(transactionAmount);
            double actualBal = bond.GetShares;

            // assert
            Assert.AreEqual(actualBal, 3300.00);

        }

        [TestMethod]
        public void EarnBonds()
        {

            //Arrange
            double beginningBal = 3300.00;
            double transactionAmount = 150.00;

            Bonds bond = new Bonds();

            //Act
            bond.Buy(beginningBal);
            bond.Earn(transactionAmount);
            double actualBal = bond.GetShares;

            // assert
            Assert.AreEqual(actualBal, 3450.00);

        }

        [TestMethod]
        public void showPortfolio()
        {

            //Arrange
            double stocksBal = 5500.00;
            double bondsBal = 3450.00;
            double annuityBal = 820.00;

            Annuity ann = new Annuity();
            Stocks sto = new Stocks();
            Bonds bond = new Bonds();

            //Act
            ann.Buy(annuityBal);
            sto.Buy(stocksBal);
            bond.Buy(bondsBal);
            double actualBal = ann.GetShares + sto.GetShares + bond.GetShares;
            
            // assert
            Assert.AreEqual(actualBal, 9770.00);

        }
    }
}
