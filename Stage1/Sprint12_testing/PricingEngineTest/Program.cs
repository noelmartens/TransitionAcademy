using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingEngineApp;

namespace PricingEngineTests
{
    [TestClass]
    public class PricingEngineTests
    {
        [TestMethod]
        public void CalculateUnitPrice_BelowMinPrice()
        {

            // 1. If the retail price is less than, or equal to $1.00, no discount

            // arrange
            PricingEngine engine = new PricingEngine(false);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 0.50m);
            // assert
            Assert.AreEqual(unitPrice, 0.50m);   // no discount < $1.00

        }

        [TestMethod]
        public void CalculateUnitPrice_MinPrice()
        {

            // 1. If the retail price is less than, or equal to $1.00, no discount
            // 2. If quantity is greater than 10 but less than, or equal to 20, then 10 % discount

            // arrange
            PricingEngine engine = new PricingEngine(false);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(11, 1.00m);
            // assert
            Assert.AreEqual(unitPrice, .900m);      // 10% discount between 10 and 20 ordered
        }

        [TestMethod]
        public void CalculateUnitPrice_BelowMinQty()
        {

            // 1. If the retail price is less than, or equal to $1.00, no discount
            // 2. If quantity is greater than 10 but less than, or equal to 20, then 10 % discount

            // arrange
            PricingEngine engine = new PricingEngine(false);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(9, 1.00m);
            // assert
            Assert.AreEqual(unitPrice, 1.000m);    // no discount < under 10 ordered
        }

        [TestMethod]
        public void CalculateUnitPrice_MinQtyLower()
        {

            // 1. If the retail price is less than, or equal to $1.00, no discount
            // 2. If quantity is greater than 10 but less than, or equal to 20, then 10 % discount

            // arrange
            PricingEngine engine = new PricingEngine(false);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(11, 1.00m);
            // assert
            Assert.AreEqual(unitPrice, 0.900m);   // 10% discount if order more than 10
        }

        [TestMethod]
        public void CalculateUnitPrice_MinQtyUpper()
        {

            // 1. If the retail price is less than, or equal to $1.00, no discount
            // 2. If quantity is greater than 10 but less than, or equal to 20, then 10 % discount

            // arrange
            PricingEngine engine = new PricingEngine(false);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(20, 1.00m);
            // assert
            Assert.AreEqual(unitPrice, .900m);   // 10% discount if order more than 10 and less than 20
        }

        [TestMethod]
        public void CalculateUnitPrice_QtyGT20()
        {
            // 1. If the retail price is less than, or equal to $1.00, no discount
            // 2. If quantity is greater than 10 but less than, or equal to 20, then 10 % discount
            // 3. If quantity greater than 20, then 20 % discount
            // arrange
            PricingEngine engine = new PricingEngine(false);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(21, 1.00m);
            // assert
            Assert.AreEqual(unitPrice, 0.800m);   // 20% discount if order more than 20
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayBelowMinPrice()
        {

            // 4. If it's a holiday and the total amount, after volume discount, is greater
            //    than the holiday threshold, then apply the holiday discount percent

            // arrange
            PricingEngine engine = new PricingEngine(true);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(1250, .99m);
            // assert
            Assert.AreEqual(unitPrice, .990m);   // holiday but under $1.00 - no discount
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayBelowMinTotal()
        {

            // 4. If it's a holiday and the total amount, after volume discount, is greater
            //    than the holiday threshold, then apply the holiday discount percent

            // arrange
            PricingEngine engine = new PricingEngine(true);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(1249, 1.00m);
            // assert
            Assert.AreEqual(unitPrice, .800m);   // holiday but under $1000.00 - only 20% volume discount
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayBelowMinQty()
        {

            // 4. If it's a holiday and the total amount, after volume discount, is greater
            //    than the holiday threshold, then apply the holiday discount percent

            // Test the discount for holiday and quantity = 10 and total
            // discounted amount is above the holiday threshold

            // arrange
            PricingEngine engine = new PricingEngine(true);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 100.01m);
            // assert
            Assert.AreEqual(unitPrice, 90.009m);   // holiday but under qty - only 10% holiday discount
        }

        [TestMethod]
        public void CalculateUnitPrice_HolidayMinQty()
        {
            // 4. If it's a holiday and the total amount, after volume discount, is greater
            //    than the holiday threshold, then apply the holiday discount percent

            // Test the discount for holiday and quantity = 10 and total
            // discounted amount is above the holiday threshold

            // arrange
            PricingEngine engine = new PricingEngine(true);
            // act
            decimal unitPrice = engine.CalculateUnitPrice(10, 100.00m);
            // assert
            Assert.AreEqual(unitPrice, 100.00m);     // holiday but not over $1000.00 - no discount
        }
    }
}