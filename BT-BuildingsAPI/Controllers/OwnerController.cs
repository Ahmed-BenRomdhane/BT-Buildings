using BT_BuildingsBL.IRepositories;
using BT_BuildingsMODELS;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BT_BuildingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpPost]
        [Route("CreateOwner")]
        public async Task<IActionResult> CreateOwner([FromBody] OwnerDTO ownerDTO)
        {
            if (ownerDTO == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "passing a null owner"
                });
            }
            var result = await _ownerRepository.CreateOwner(ownerDTO);
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMeassge = null
            });
        }

        [HttpPost]
        [Route("IsOwnerExists")]
        public async Task<IActionResult> IsOwnerExists([FromBody] int? ownerCIN)
        {
            if (ownerCIN == null || ownerCIN < 0 || ownerCIN > 99999999)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMeassge = "invalid CIN number"
                });
            }
            var result = await _ownerRepository.IsOwnerAlreadyExists((int)ownerCIN);
            if (result == null)
            {
                return NotFound(new APIResult()
                {
                    Success = true,
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Data = result,
                    ErrorMeassge = null
                });
            }
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.NoContent,
                Data = result,
                ErrorMeassge = null
            });
        }
    }
}
