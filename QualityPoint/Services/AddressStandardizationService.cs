using Dadata.Model;
using QualityPoint.Interfaces;

namespace QualityPoint.Services
{
    public class AddressStandardizationService : IAddressStandardizationService
    {
        private readonly IDadataService _dadataService;

        public AddressStandardizationService(IDadataService dadataService)
        {
            _dadataService = dadataService;
        }

        public async Task<Address> StandardizeAddressAsync(string address)
        {
            try
            {
                var cleanAddress = await _dadataService.CleanAddressAsync(address);
                return cleanAddress;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}
