using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Services;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using IoT.Application.CityAppService.DTO;
using IoT.Core.Cities;
using IoT.Core;
using IoT.Core.MongoDb;
using Masuit.Tools;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUglify.Helpers;
using System.Linq.Dynamic.Core;
using System.Linq;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace IoT.Application.CityAppService
{
    public class CityAppService:ApplicationService,ICityAppService
    {
        private readonly ICityManager _cityManager;
        private readonly ICityRepository _cityRepository;

        public CityAppService(ICityManager cityManager, ICityRepository cityRepository)
        {
            _cityManager = cityManager;
            _cityRepository = cityRepository;
        }


        public CityDto Get(EntityDto<int> input)
        {
            var entity = _cityRepository.Get(input.Id);
            return entity.MapTo<CityDto>();
        }

        public PagedResultDto<CityDto> GetAll(CityPagedSortedAndFilteredDto input)
        {
            var query = _cityRepository.GetAll();
            var total = query.Count();
            var result = input.Sorting != null
                ? query.OrderBy(input.Sorting).AsNoTracking().PageBy(input).ToList()
                : query.PageBy(input).ToList();
            return new PagedResultDto<CityDto>(total,ObjectMapper.Map<List<CityDto>>(result));

        }
        /*
        public PagedResultDto<CityDto> GetAll(PagedResultRequestDto input)
        {
            var query = _cityRepository.GetAll();
            int total = query.Count();
            var result = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList<City>();
            return new PagedResultDto<CityDto>(total,new List<CityDto>(
                ObjectMapper.Map<List<CityDto>>(result)));
        }
        */
        public CityDto Create(CreateCityDto input)
        {
            string requestUrl= "https://restapi.amap.com/v3/geocode/geo?address=" + input.CityName +
                               "&key=c6d99b34598e3721a00fb609eb4a4c1b";
            CityGeoDto cityGeo=new CityGeoDto();
            using (HttpClient client=new HttpClient())
            {
                HttpResponseMessage responseMessage = client.GetAsync(requestUrl).Result;
                cityGeo =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<CityGeoDto>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            if (!cityGeo.geocodes.Any())
            {
                throw new ArgumentException("Error Input");
            }
            GeocodeModel geoModel = cityGeo.geocodes[0];
            var location = geoModel.location.Split(",");
            var entity = new City()
            {
                CityName = geoModel.city,
                CityCode = geoModel.citycode,
                Longitude = decimal.Parse(location[0]),
                Latitude = decimal.Parse(location[1])
            };
            var city = _cityRepository.GetAll().Where(c => c.CityCode == entity.CityCode);
            if (city.Any())
            {
                throw new ApplicationException("城市已存在！");
            }
            var result = _cityRepository.Create(entity);
            CurrentUnitOfWork.SaveChanges();
            return result.MapTo<CityDto>();
        }

        public CityDto Update(UpdateCityDto input)
        {
            var city = _cityRepository.Get(input.Id);
            if (city.IsNullOrDeleted())
            {
                throw new ArgumentException("Error Input");
            }

            city.Remark = input.Remark;
            var result= _cityRepository.Update(city);
            CurrentUnitOfWork.SaveChanges();
            return result.MapTo<CityDto>();
        }

        public void Delete(EntityDto<int> input)
        {
            /*删除城市，城市的实验楼提示是否删除*/
            var city = _cityRepository.Get(input.Id);
            if (city.IsNullOrDeleted())
            {
                throw new ArgumentException("城市不存在或已删除");
            }
            _cityManager.Delete(city);
        }
    }
}
