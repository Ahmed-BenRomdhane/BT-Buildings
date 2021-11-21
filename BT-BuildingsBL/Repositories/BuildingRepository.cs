using AutoMapper;
using BT_BuildingsBL.IRepositories;
using BT_BuildingsDAL;
using BT_BuildingsMODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BT_BuildingsBL.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public BuildingRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<BuildingDTO> CreateBuilding(BuildingDTO buildingDTO)
        {
            var building = _mapper.Map<BuildingDTO, Building>(buildingDTO);
            building.PublishDate = DateTime.Now;
            building.TotalViews = 0;
            building.TotalLikes = 0;
            var newBuilding = await _db.Buildings.AddAsync(building);
            await _db.SaveChangesAsync();
            return _mapper.Map<Building, BuildingDTO>(newBuilding.Entity);
        }

        public async Task<Guid> DeleteBuilding(Guid buildingId)
        {
            var building = await _db.Buildings.FindAsync(buildingId);
            if (building != null)
            {
                var allBuildingimages = await _db.BuildingImages.Where(b => b.BuildingId == buildingId).ToListAsync();
                _db.BuildingImages.RemoveRange(allBuildingimages);
                _db.Buildings.Remove(building);
                await _db.SaveChangesAsync();
            }
            return buildingId;
        }

        public async Task<BuildingDTO> UpdateBuilding(Guid buildingId, BuildingDTO buildingDTO)
        {
            try
            {
                if (buildingId == buildingDTO.Id)
                {
                    Building building = _mapper.Map(buildingDTO, await _db.Buildings.FindAsync(buildingId));
                    building.PublishDate = DateTime.Now;
                    var updatedBuilding = _db.Buildings.Update(building);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Building, BuildingDTO>(updatedBuilding.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<BuildingDTO> GetAllBuildings()
        {
            try
            {
                return _mapper.Map<IEnumerable<Building>, IEnumerable<BuildingDTO>>(_db.Buildings.Include(b => b.BuildingImages));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BuildingDTO> GetBuilding(Guid buildingId)
        {
            try
            {
                return _mapper.Map<Building, BuildingDTO>(_db.Buildings.Include(b => b.BuildingImages).Include(b => b.Owner).Include(b => b.Address).
                    FirstOrDefault(building => building.Id == buildingId));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BuildingDTO> IsBuildingAlreadyExists(string name, double price)
        {
            var building = await _db.Buildings.FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower() && b.Price == price);
            if (building != null)
            {
                return _mapper.Map<Building, BuildingDTO>(building);
            }
            return null;
        
        }
    }
}
