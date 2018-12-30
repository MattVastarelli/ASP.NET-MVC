using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.DTOS;
using App.Models;
using AutoMapper;

namespace App.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<Movie, MoviesDTO>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MoviesDTO, Movie>();

            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
        }

    }
}