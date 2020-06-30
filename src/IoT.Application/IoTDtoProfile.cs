using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using IoT.Application.CityAppService.DTO;
using IoT.Application.DeviceAppService;
using IoT.Application.FactoryAppService.DTO;
using IoT.Application.GatewayAppService.DTO;
using IoT.Application.WorkshopAppService.DTO;
using IoT.Core;

namespace IoT.Application
{
    public class IoTDtoProfile:Profile
    {
        public IoTDtoProfile()
        {
            //City
            CreateMap<City, CityDto>();
            CreateMap<CreateCityDto, City>();
            CreateMap<UpdateCityDto, City>();
            //Factory
            CreateMap<Factory, FactoryDto>()
                .ForMember(des => des.CityName,
                    opt => opt.MapFrom(i => i.City.CityName));
            CreateMap<CreateFactoryDto, Factory>();
            //Workshop
            CreateMap<Workshop, WorkshopDto>()
                .ForMember(des => des.FactoryName,
                    opt => opt.MapFrom(i => i.Factory.FactoryName))
                .ForMember(des=>des.CityName,
                    opt=>opt.MapFrom(i=>i.Factory.City.CityName));
            CreateMap<CreateWorkshopDto, Workshop>();
            //GatewayType
            CreateMap<GatewayType, GatewayTypeDto>();
            CreateMap<CreateGatewayTypeDto, GatewayType>();
            //Gateway
            CreateMap<Gateway, GatewayDto>()
                .ForMember(des => des.WorkshopName,
                    opt => opt.MapFrom(i => i.Workshop.WorkshopName))
                .ForMember(des => des.FactoryName,
                    opt => opt.MapFrom(i => i.Workshop.Factory.FactoryName))
                .ForMember(des => des.CityName,
                    opt => opt.MapFrom(i => i.Workshop.Factory.City.CityName))
                .ForMember(des=>des.GatewayTypeName,
                    opt=>opt.MapFrom(i=>i.GatewayType.TypeName));
            CreateMap<CreateGatewayDto, Gateway>();
            //Tag
            CreateMap<Tag, TagDto>();
            CreateMap<CreateTagDto, Tag>();
        }
    }
}
