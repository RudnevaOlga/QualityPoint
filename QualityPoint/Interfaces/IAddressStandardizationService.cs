using Dadata.Model;

namespace QualityPoint.Interfaces
{
    public interface IAddressStandardizationService
    {
        Task<Address> StandardizeAddressAsync(string address);
    }
}
