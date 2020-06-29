using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using IoT.Application.WorkshopAppService.DTO;
using IoT.Core;
using L._52ABP.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace IoT.Application.WorkshopAppService
{
    public class WorkshopAppService:ApplicationService,IWorkshopAppService
    {
        private readonly IRepository<Workshop, int> _workshopRepository;
        private readonly IRepository<Factory, int> _factoryRepository;
        private readonly IRepository<City, int> _cityRepository;

        public WorkshopAppService(IRepository<Workshop, int> workshopRepository, IRepository<Factory, int> factoryRepository, IRepository<City, int> cityRepository)
        {
            _workshopRepository = workshopRepository;
            _factoryRepository = factoryRepository;
            _cityRepository = cityRepository;
        }


        public WorkshopDto Get(EntityDto<int> input)
        {
            var query = _workshopRepository.GetAllIncluding(w => w.Factory)
                .Include(w => w.Factory.City).Where(w => w.Id == input.Id);
            var entity = query.FirstOrDefault();
            return ObjectMapper.Map<WorkshopDto>(entity);
        }

        public PagedResultDto<WorkshopDto> GetAll(PagedSortedAndFilteredInputDto input)
        {
            var query = _workshopRepository.GetAllIncluding(w=>w.Factory)
                .Include(w=>w.Factory.City);
            var total = query.Count();
            var result = input.Sorting != null
                ? query.OrderBy(input.Sorting).AsNoTracking().PageBy(input).ToList()
                : query.PageBy(input).ToList();
            return new PagedResultDto<WorkshopDto>(total, ObjectMapper.Map<List<WorkshopDto>>(result));
        }

        public WorkshopDto Create(CreateWorkshopDto input)
        {
            var cityQuery = _cityRepository.GetAll().Where(c => c.CityName == input.CityName);
            var city = cityQuery.FirstOrDefault();
            if (city.IsNullOrDeleted())
            {
                throw new ApplicationException("City不存在或输入错误");
            }

            var factoryQuery = _factoryRepository.GetAll().Where(f => f.FactoryName == input.FactoryName);
            var factory = factoryQuery.FirstOrDefault();
            if (factory.IsNullOrDeleted())
            {
                throw new ApplicationException("Workshop不存在或输入错误");
            }

            var workshopQuery = _workshopRepository.GetAll().Where(w => w.WorkshopName == input.WorkshopName);
            if (workshopQuery.Any())
            {
                throw new ApplicationException("WorkshopName重复");
            }

            var entity = ObjectMapper.Map<Workshop>(input);
            entity.Factory = factory;
            var result = _workshopRepository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<WorkshopDto>(result);
        }

        public WorkshopDto Update(CreateWorkshopDto input)
        {
            var cityQuery = _cityRepository.GetAll().Where(c => c.CityName == input.CityName);
            var city = cityQuery.FirstOrDefault();
            if (city.IsNullOrDeleted())
            {
                throw new ApplicationException("City不存在或输入错误");
            }

            var factoryQuery = _factoryRepository.GetAll().Where(f => f.FactoryName == input.FactoryName);
            var factory = factoryQuery.FirstOrDefault();
            if (factory.IsNullOrDeleted())
            {
                throw new ApplicationException("Workshop不存在或输入错误");
            }

            var workshop = _workshopRepository.Get(input.Id);
            ObjectMapper.Map(input, workshop);
            workshop.Factory = factory;
            var result = _workshopRepository.Update(workshop);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<WorkshopDto>(workshop);
        }

        public void Delete(EntityDto<int> input)
        {
            var entity = _workshopRepository.Get(input.Id);
            _workshopRepository.Delete(entity);
        }
    }
}
