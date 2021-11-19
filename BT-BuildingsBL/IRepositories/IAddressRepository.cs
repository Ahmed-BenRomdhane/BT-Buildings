using BT_BuildingsMODELS;
using System.Threading.Tasks;

namespace BT_BuildingsBL.IRepositories
{
    public interface IAddressRepository
    {
        public Task<AddressDTO> CreateAddress(AddressDTO addressDTO);
    }
}
