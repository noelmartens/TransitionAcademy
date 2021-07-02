using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Common.Contracts;
using DPLRef.eCommerce.Common.Shared;


public interface ITaxRateAccessor : IServiceContractBase
{
    decimal Rate(Address address);
}

class TaxRateAccessor : AccessorBase, ITaxRateAccessor
{
    public decimal Rate(Address address)
    {
        USATaxer.USATaxerLib taxer = new USATaxer.USATaxerLib();
        taxer.Init();
        return taxer.Rate(address.Postal);
    }
}
