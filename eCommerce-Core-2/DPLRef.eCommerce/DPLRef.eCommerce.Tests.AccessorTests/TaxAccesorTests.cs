

using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Common.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DPLRef.eCommerce.Tests.AccessorTests
{
    [TestClass]
    public class TaxAccessorTests
    {
        private ITaxRateAccessor CreateAccessor()
        {
            var context = new Common.Contracts.AmbientContext();
            var factory = new AccessorFactory(
                context,
                new Utilities.UtilityFactory(context));
            return factory.CreateAccessor<ITaxRateAccessor>();
        }

        [TestMethod]
        public void TaxAccessor_LincolnNe()
        {
            var accessor = CreateAccessor();
            var lincoln = new Address()
            {
                Postal = "68512"
            };
            accessor.Rate(lincoln);
            Assert.AreEqual(0.0725m, accessor.Rate(lincoln));
        }
    }

}