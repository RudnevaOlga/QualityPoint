using Dadata.Model;

namespace QualityPoint.Interfaces
{
    public interface IDadataService
    {
        Task<Address> CleanAddressAsync(string address);
    }
}
