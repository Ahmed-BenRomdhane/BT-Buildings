using AutoMapper;
using BT_BuildingsBL.IRepositories;
using BT_BuildingsDAL;
using BT_BuildingsMODELS;
using System;
using System.Collections.Generic;
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
        public Task<BuildingDTO> CreateBuilding(BuildingDTO building)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteBuilding(Guid buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BuildingDTO>> GetAllBuildings()
        {
            throw new NotImplementedException();
        }

        public Task<BuildingDTO> GetBuilding(Guid buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<BuildingDTO> IsBuildingAlreadyExists(string name, double price)
        {
            throw new NotImplementedException();
        }

        public Task<BuildingDTO> UpdateBuilding(Guid buildingId, BuildingDTO building)
        {
            throw new NotImplementedException();
        }
    }
}
