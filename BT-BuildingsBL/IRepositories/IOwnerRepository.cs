using BT_BuildingsMODELS;
using System.Threading.Tasks;

namespace BT_BuildingsBL.IRepositories
{
    public interface IOwnerRepository
    {
        public Task<OwnerDTO> CreateOwner(OwnerDTO ownerDTO);
        public Task<OwnerDTO> GetOwner(int ownerCIN);
        public Task<OwnerDTO> IsOwnerAlreadyExists(int ownerCIN);
    }
}
