using AutoMapper;
using BT_BuildingsBL.IRepositories;
using BT_BuildingsDAL;
using BT_BuildingsMODELS;
using System;
using System.Threading.Tasks;

namespace BT_BuildingsBL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AddressRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<AddressDTO> CreateAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<AddressDTO, Address>(addressDTO);
            var addedAddress = await _db.Addresses.AddAsync(address);
            await _db.SaveChangesAsync();
            return _mapper.Map<Address, AddressDTO>(addedAddress.Entity);
        }
    }
}
