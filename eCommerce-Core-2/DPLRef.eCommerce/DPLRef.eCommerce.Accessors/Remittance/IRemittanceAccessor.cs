using DPLRef.eCommerce.Accessors.DataTransferObjects;
using DPLRef.eCommerce.Common.Shared;
using System;

namespace DPLRef.eCommerce.Accessors.Remittance
{
    public interface IRemittanceAccessor : IServiceContractBase
    {
        SellerOrderData[] SalesTotal();
        decimal SalesTax(string zipcode, DateTime start, DateTime end);
    }
}
