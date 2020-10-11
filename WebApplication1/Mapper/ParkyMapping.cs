﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NationalParkDemo.Models;
using NationalParkDemo.Repository;

namespace NationalParkDemo.Mapper
{
    public class ParkyMapping : Profile
    {
        public ParkyMapping()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
        }
    }
}
