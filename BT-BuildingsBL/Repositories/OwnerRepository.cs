using AutoMapper;
using BT_BuildingsBL.IRepositories;
using BT_BuildingsDAL;
using BT_BuildingsMODELS;
using System.Threading.Tasks;
using System.Linq;

namespace BT_BuildingsBL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public OwnerRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OwnerDTO> CreateOwner(OwnerDTO ownerDTO)
        {
            var owner = _mapper.Map<OwnerDTO, Owner>(ownerDTO);
            var addedAddress = await _db.Owners.AddAsync(owner);
            await _db.SaveChangesAsync();
            return _mapper.Map<Owner, OwnerDTO>(addedAddress.Entity);
        }

        public async Task<OwnerDTO> GetOwner(int ownerCIN)
        {
            return _mapper.Map<Owner, OwnerDTO>(await _db.Owners.FindAsync(ownerCIN));
        }

        public async Task<OwnerDTO> IsOwnerAlreadyExists(int ownerCIN)
        {
            var owner = await _db.Owners.FindAsync(ownerCIN);
            if (owner != null)
            {
                return _mapper.Map<Owner, OwnerDTO>(owner);
            }
            return null;
        }
    }
}
