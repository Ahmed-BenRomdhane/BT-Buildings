using BT_BuildingsMODELS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BT_BuildingsBL.IRepositories
{
    public interface IBuildingImagesRepository
    {
        public Task<BuildingImageDTO> CreateBuildingImage(BuildingImageDTO buildingImageDTO);
        public Task<Guid> DeleteBuildingImagesByBuildingId(Guid buildingId);
        public Task<Guid> DeleteBuildingImageByImageId(Guid imageId);
        public Task<IEnumerable<BuildingImageDTO>> GetAllBuildingImages(Guid buildingId);
    }
}
