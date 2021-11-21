using BT_BuildingsBL.IRepositories;
using BT_BuildingsMODELS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BT_BuildingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        [HttpPost]
        [Route("CreateBuilding")]
        public async Task<IActionResult> CreateBuilding([FromBody] BuildingDTO buildingDTO)
        {
            if (buildingDTO == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "building cannot be null"
                });
            }
            if (string.IsNullOrEmpty(buildingDTO.Name))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "building name is mandatory"
                });
            }
            if (double.IsNaN(buildingDTO.Price) || buildingDTO.Price < 0)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "building price is invalid"
                });
            }
            var result = await _buildingRepository.CreateBuilding(buildingDTO);
            if (result == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null,
                    ErrorMessage = "there was a problem when creating a new building"
                });
            }
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }

        [HttpPost]
        [Route("UpdateBuilding")]
        public async Task<IActionResult> UpdateBuilding(Guid buildingId, BuildingDTO buildingDTO)
        {
            if (buildingDTO == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "building cannot be null"
                });
            }
            var result = await _buildingRepository.UpdateBuilding(buildingId, buildingDTO);
            if (result == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null,
                    ErrorMessage = "there was a problem when updating a new building"
                });
            }
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }

        [HttpDelete]
        [Route("DeleteBuilding")]
        public async Task<IActionResult> DeleteBuilding([FromBody] Guid buildingId)
        {
            if (Guid.Empty == buildingId)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "building cannot be empty"
                });
            }
            var result = await _buildingRepository.DeleteBuilding(buildingId);
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }

        [HttpPost]
        [Route("GetBuilding")]
        public async Task<IActionResult> GetBuilding([FromBody] Guid buildingId)
        {
            if (Guid.Empty == buildingId)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "building cannot be empty"
                });
            }
            var result = await _buildingRepository.GetBuilding(buildingId);
            if (result == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null,
                    ErrorMessage = "there was a problem when getting a new building"
                });
            }
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }

        [HttpPost]
        [Route("IsBuildingAlreadyExists")]
        public async Task<IActionResult> IsBuildingAlreadyExists([FromBody] string name, double price)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "name cannot be empty"
                });
            }
            if (price < 0)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "price is invalid"
                });
            }
            var result = await _buildingRepository.IsBuildingAlreadyExists(name, price);
            if (result == null)
            {
                return NotFound(new APIResult()
                {
                    Success = true,
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Data = "building does not exist",
                    ErrorMessage = null
                });
            }
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }

        [HttpGet]
        [Route("GetAllBuildings")]
        public IActionResult GetAllBuildings()
        {
            var result = _buildingRepository.GetAllBuildings();
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }
    }
}
