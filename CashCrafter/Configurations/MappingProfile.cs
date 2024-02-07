﻿using AutoMapper;
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
        }
    }
}