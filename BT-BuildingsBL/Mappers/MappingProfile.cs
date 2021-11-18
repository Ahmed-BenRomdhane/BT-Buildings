using AutoMapper;
using BT_BuildingsDAL;
using BT_BuildingsMODELS;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BuildingDTO, Building>().ReverseMap();
            CreateMap<OwnerDTO, Owner>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
        }
    }
}
