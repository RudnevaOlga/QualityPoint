using Dadata.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QualityPoint.Interfaces;

namespace QualityPoint.Controllers
{
    [Route("DaData")]
    [AllowAnonymous]
    public class AddressStandardizationController : ControllerBase
    {
        private readonly IAddressStandardizationService _addressStandardizationService;

        public AddressStandardizationController(IAddressStandardizationService addressStandardizationService)
        {
            _addressStandardizationService = addressStandardizationService;
        }

        [HttpGet("GetStandardizeAddress")]
        public async Task<ActionResult<Address>> StandardizeAddress(string address)
        {
            var standardizedAddress = await _addressStandardizationService.StandardizeAddressAsync(address);
            return Ok(standardizedAddress);
        }
    }
}
