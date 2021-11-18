using BT_BuildingsMODELS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BT_BuildingsBL.IRepositories
{
    public interface IBuildingRepository
    {
        public Task<BuildingDTO> CreateBuilding(BuildingDTO building);
        public Task<BuildingDTO> UpdateBuilding(Guid buildingId, BuildingDTO building);
        public Task<Guid> DeleteBuilding(Guid buildingId);
        public Task<IEnumerable<BuildingDTO>> GetAllBuildings();
        public Task<BuildingDTO> GetBuilding(Guid buildingId);
        public Task<BuildingDTO> IsBuildingAlreadyExists(string name, double price);
    }
}
