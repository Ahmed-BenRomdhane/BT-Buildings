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
    public class BuildingImagesController : Controller
    {
        private readonly IBuildingImagesRepository _buildingImagesRepository;

        public BuildingImagesController(IBuildingImagesRepository buildingImagesRepository)
        {
            _buildingImagesRepository = buildingImagesRepository;
        }

        [HttpPost]
        [Route("CreateBuildingImage")]
        public async Task<IActionResult> CreateBuildingImage([FromBody] BuildingImageDTO buildingImageDTO)
        {
            if (buildingImageDTO == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "image cannot be null"
                });
            }
            var result = await _buildingImagesRepository.CreateBuildingImage(buildingImageDTO);
            if (result == null)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null,
                    ErrorMessage = "there was a problem when creating a new image"
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
        [Route("DeleteBuildingImagesByBuildingId")]
        public async Task<IActionResult> DeleteBuildingImagesByBuildingId([FromBody] Guid buildingId)
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
            var result = await _buildingImagesRepository.DeleteBuildingImagesByBuildingId(buildingId);
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }

        [HttpPost]
        [Route("DeleteBuildingImageByImageId")]
        public async Task<IActionResult> DeleteBuildingImageByImageId([FromBody] Guid imageId)
        {
            if (Guid.Empty == imageId)
            {
                return BadRequest(new APIResult()
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    ErrorMessage = "image cannot be empty"
                });
            }
            var result = await _buildingImagesRepository.DeleteBuildingImageByImageId(imageId);
            return Ok(new APIResult()
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK,
                Data = result,
                ErrorMessage = null
            });
        }

        [HttpGet]
        [Route("GetAllBuildingImages")]
        public async Task<IActionResult> GetAllBuildingImages([FromBody] Guid buildingId)
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
            var result = await _buildingImagesRepository.GetAllBuildingImages(buildingId);
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
