using BT_BuildingsBL.IRepositories;
using BT_BuildingsMODELS;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BT_BuildingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpPost]
        [Route("CreateAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDTO addressDTO)
        {
            if (addressDTO == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "address cannot be null"
                });
            }
            if (string.IsNullOrEmpty(addressDTO.City))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "City is mandatory"
                });
            }
            if (string.IsNullOrEmpty(addressDTO.CountryCode))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "CountryCode is mandatory"
                });
            }
            if (string.IsNullOrEmpty(addressDTO.HouseNumber))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "HouseNumber is mandatory"
                });
            }
            if (string.IsNullOrEmpty(addressDTO.PostalCode))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "PostalCode is mandatory"
                });
            }
            if (string.IsNullOrEmpty(addressDTO.Province))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "Province is mandatory"
                });
            }
            if (string.IsNullOrEmpty(addressDTO.StreetName))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "StreetName is mandatory"
                });
            }
            var result = await _addressRepository.CreateAddress(addressDTO);
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMeassge = null
            });
        }
    }
}
