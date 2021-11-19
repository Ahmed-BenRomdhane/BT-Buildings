using BT_BuildingsMODELS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BT_BuildingsBL.IRepositories
{
    public interface IBuildingRepository
    {
        public Task<BuildingDTO> CreateBuilding(BuildingDTO buildingDTO);
        public Task<BuildingDTO> UpdateBuilding(Guid buildingId, BuildingDTO buildingDTO);
        public Task<Guid> DeleteBuilding(Guid buildingId);
        public Task<BuildingDTO> GetBuilding(Guid buildingId);
        public Task<BuildingDTO> IsBuildingAlreadyExists(string name, double price);
        public IEnumerable<BuildingDTO> GetAllBuildings();
    }
}
