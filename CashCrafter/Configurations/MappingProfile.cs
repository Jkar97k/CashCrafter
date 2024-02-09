using AutoMapper;
using CashCrafter.Api.DTO;
using CashCrafter.Api.Model;

namespace CashCrafter.Api.Configurations
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User, PostUserDTO>().ReverseMap();
            CreateMap<User, PutUserDTO>().ReverseMap();
            CreateMap<Ubicacion,UbicacionDTO>().ReverseMap();
            CreateMap<Ubicacion, PostUbicacionDTO>().ReverseMap();
            CreateMap<TipoPago,TipoPagoDTO>().ReverseMap();
            CreateMap<TipoPago,PostTipoPagoDTO>().ReverseMap();
            CreateMap<TipoIngreso,TipoIngresoDTO>().ReverseMap();
            CreateMap<TipoIngreso, PostTipoIngresoDTO>().ReverseMap();
            CreateMap<TipoAhorro,TipoAhorroDTO>().ReverseMap();
            CreateMap<TipoAhorro, PostTipoAhorroDTO>().ReverseMap();

        }
    }
}
