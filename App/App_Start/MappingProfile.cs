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
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }

    }
}