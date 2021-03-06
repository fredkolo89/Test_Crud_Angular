﻿using AutoMapper;
using Roxa.BLL;
using Roxa.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserBll>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
                   
            CreateMap<User, UserBll>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap(); 
        }
    }
}
