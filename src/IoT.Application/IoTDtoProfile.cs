using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using IoT.Application.CityAppService.DTO;
using IoT.Application.FactoryAppService.DTO;
using IoT.Application.WorkshopAppService.DTO;
using IoT.Core;

namespace IoT.Application
{
    public class IoTDtoProfile:Profile
    {
        public IoTDtoProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<CreateCityDto, City>();
            CreateMap<UpdateCityDto, City>();

            CreateMap<Factory, FactoryDto>()
                .ForMember(des => des.CityName,
                    opt => opt.MapFrom(i => i.City.CityName));
            CreateMap<CreateFactoryDto, Factory>();

            CreateMap<Workshop, WorkshopDto>()
                .ForMember(des => des.FactoryName,
                    opt => opt.MapFrom(i => i.Factory.FactoryName))
                .ForMember(des=>des.CityName,
                    opt=>opt.MapFrom(i=>i.Factory.City.CityName));
        }
    }
}
