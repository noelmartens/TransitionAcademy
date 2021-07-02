﻿using System.Linq;
using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Common.Contracts;
using DPLRef.eCommerce.Managers;
using DPLRef.eCommerce.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Admin = DPLRef.eCommerce.Contracts.Admin.Sales;
using BackOffice = DPLRef.eCommerce.Contracts.BackOfficeAdmin.Remittance;
using acc = DPLRef.eCommerce.Accessors.Sales;
using accRemittance = DPLRef.eCommerce.Accessors.Remittance;
using DPLRef.eCommerce.Tests.Mocks;

namespace DPLRef.eCommerce.Tests.ManagerTests
{

    [TestClass]
    public class RemittanceManagerTests 
    {
        #region Test Data

        private MockData mockData = new()
        {
            Context = new AmbientContext()
            {
                AuthToken = "auth token"
            }
        };

        #endregion  

        #region Factory

        private BackOffice.IBackOfficeRemittanceManager GetBackOfficeManager()
        {
            ManagerFactory mgrFactory = new(mockData.Context);
            return mgrFactory.CreateManager<BackOffice.IBackOfficeRemittanceManager>(null, SetupMockAccessorFactory(), SetupMockUtilityFactory());
        }

        private Admin.IAdminRemittanceManager GetAdminManager()
        {
            ManagerFactory mgrFactory = new(mockData.Context);
            return mgrFactory.CreateManager<Admin.IAdminRemittanceManager>(null, SetupMockAccessorFactory(), SetupMockUtilityFactory());
        }

        private AccessorFactory SetupMockAccessorFactory()
        {
            AccessorFactory accFactory = new(mockData.Context, new UtilityFactory(new AmbientContext()));

            var mockOrderAccessor = new MockOrderAccessor(mockData);            
            accFactory.AddOverride<acc.IOrderAccessor>(mockOrderAccessor);

            var mockRemittanceAccessor = new MockRemittanceAccessor(mockData);
            accFactory.AddOverride<accRemittance.IRemittanceAccessor>(mockRemittanceAccessor);

            return accFactory;
        }
       
        public UtilityFactory SetupMockUtilityFactory()
        {
            UtilityFactory utilFactory = new(mockData.Context);
            MockSecurityUtility mockSecurity = new(mockData);
            utilFactory.AddOverride<ISecurityUtility>(mockSecurity);
            return utilFactory;
        }

        #endregion

        #region BackOffice

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void RemittanceManager_BackOffice_Totals()
        {
            var mgr = GetBackOfficeManager();

            var totals = mgr.Totals();
            Assert.IsNotNull(totals);
            Assert.IsTrue(totals.Success);
            Assert.AreEqual(1, totals.SellerOrderData.Length);
            Assert.AreEqual(1, totals.SellerOrderData.First().OrderCount);
            Assert.AreEqual(10.0M, totals.SellerOrderData.First().OrderTotal);
            Assert.AreEqual(1.0M, totals.SellerOrderData.First().FeeAmount);
            Assert.AreEqual(9.0M, totals.SellerOrderData.First().RemittanceAmount);
        }

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void RemittanceManager_BackOffice_Totals_Auth()
        {
            var mgr = GetBackOfficeManager();

            mockData.Context.AuthToken = null;

            var totals = mgr.Totals();
            Assert.IsNotNull(totals);
            Assert.IsFalse(totals.Success);
            Assert.AreEqual("BackOfficeAdmin not authenticated", totals.Message);
        }

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void RemittanceManager_BackOffice_Totals_NoResults()
        {
            var mgr = GetBackOfficeManager();

            mockData.SellerOrderData.Clear();

            var totals = mgr.Totals();
            Assert.IsNotNull(totals);
            Assert.IsFalse(totals.Success);
            Assert.AreEqual("No orders", totals.Message);
        }


        [TestMethod]                                                //noel
        [TestCategory("Managers-WebStore")]
        public void RemittanceManager_BackOffice_SalesTax()
        {
            var mgr = GetBackOfficeManager();
            var tax = mgr.RecentSalesTax("68508");
            Assert.AreEqual(5.0M, tax);
        }



        #endregion

        #region Admin

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void RemittanceManager_Totals()
        {
            var mgr = GetAdminManager();

            var totals = mgr.Totals();
            Assert.IsNotNull(totals);
            Assert.IsTrue(totals.Success);
            Assert.AreEqual(1, totals.OrderCount);
            Assert.AreEqual(10.0M, totals.OrderTotal);           
        }

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void RemittanceManager_Totals_Auth()
        {
            var mgr = GetAdminManager();

            this.mockData.Context.AuthToken = null;

            var totals = mgr.Totals();
            Assert.IsNotNull(totals);
            Assert.IsFalse(totals.Success);
            Assert.AreEqual("Seller not authenticated", totals.Message);
        }

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void RemittanceManager_Totals_NoResults()
        {
            var mgr = GetAdminManager();

            mockData.SellerSalesTotal = null;

            var totals = mgr.Totals();
            Assert.IsNotNull(totals);
            Assert.IsFalse(totals.Success);
            Assert.AreEqual("No orders for this Seller", totals.Message);          
        }

        #endregion
    }
}
