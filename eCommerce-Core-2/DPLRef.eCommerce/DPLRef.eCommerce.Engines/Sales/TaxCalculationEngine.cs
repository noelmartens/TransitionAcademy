using DPLRef.eCommerce.Accessors.Catalog;
using DPLRef.eCommerce.Accessors.Sales;
using DPLRef.eCommerce.Contracts.WebStore.Sales;
using System;

namespace DPLRef.eCommerce.Engines.Sales
{
    class TaxCalculationEngine : EngineBase, ITaxCalculationEngine
    {
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            return input;
        }

        public WebStoreCart CalculateCartTax(WebStoreCart cart)
        {
            // TODO: Make this real. Mocking for now

            if (cart != null && cart.BillingAddress != null && !string.IsNullOrWhiteSpace(cart.BillingAddress.Postal))
            {
                var taxRate =
                AccessorFactory.CreateAccessor<ITaxRateAccessor>()
                .Rate(cart.BillingAddress);
                ICatalogAccessor catAccessor =                              // noel
                    AccessorFactory.CreateAccessor<ICatalogAccessor>();     // noel

                foreach (var item in cart.CartItems)
                {
                    var product = catAccessor.FindProduct(item.ProductId);  // noel
                    if (product.IsDownloadable == true ||                   // noel
                        product.IsTaxExempt == true)                        // noel
                    {                                                       // noel
                        taxRate = 0;                                        // noel  no tax on downloads
                    }                                                       // noel
                    cart.TaxAmount += Math.Round(item.ExtendedPrice * taxRate, 2);
                }

                // update the cart total with the tax amount
                cart.Total += Math.Round(cart.TaxAmount, 2);
            }
            return cart;
        }

    }
}
