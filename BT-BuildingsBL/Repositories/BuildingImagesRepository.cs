using AutoMapper;
using BT_BuildingsBL.IRepositories;
using BT_BuildingsDAL;
using BT_BuildingsMODELS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BT_BuildingsBL.Repositories
{
    public class BuildingImagesRepository : IBuildingImagesRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BuildingImagesRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<BuildingImageDTO> CreateBuildingImage(BuildingImageDTO buildingImageDTO)
        {
            try
            {
                var image = _mapper.Map<BuildingImageDTO, BuildingImage>(buildingImageDTO);
                await _db.AddAsync(image);
                await _db.SaveChangesAsync();
                return buildingImageDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Guid> DeleteBuildingImagesByBuildingId(Guid buildingId)
        {
            var allImages = await _db.BuildingImages.Where(b => b.BuildingId == buildingId).ToListAsync();
            _db.BuildingImages.RemoveRange(allImages);
            await _db.SaveChangesAsync();
            return buildingId;
        }

        public async Task<Guid> DeleteBuildingImageByImageId(Guid imageId)
        {
            var image = await _db.BuildingImages.FindAsync(imageId);
            _db.BuildingImages.Remove(image);
            await _db.SaveChangesAsync();
            return imageId;
        }

        public async Task<IEnumerable<BuildingImageDTO>> GetAllBuildingImages(Guid buildingId)
        {
            return _mapper.Map<IEnumerable<BuildingImage>, IEnumerable<BuildingImageDTO>>(
                await _db.BuildingImages.Where(b => b.BuildingId == buildingId).ToListAsync());
        }
    }
}
