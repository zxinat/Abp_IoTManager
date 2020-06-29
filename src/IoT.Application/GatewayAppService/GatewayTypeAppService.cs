using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using IoT.Application.GatewayAppService.DTO;
using IoT.Core;
using L._52ABP.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace IoT.Application.GatewayAppService
{
    public class GatewayTypeAppService:ApplicationService,IGatewayTypeAppService
    {
        private readonly IRepository<GatewayType, int> _gatewayTypeRepository;

        public GatewayTypeAppService(IRepository<GatewayType, int> gatewayTypeRepository)
        {
            _gatewayTypeRepository = gatewayTypeRepository;
        }

        public GatewayTypeDto Get(EntityDto<int> input)
        {
            var entity = _gatewayTypeRepository.Get(input.Id);
            return ObjectMapper.Map<GatewayTypeDto>(entity);
        }

        public PagedResultDto<GatewayTypeDto> GetAll(PagedSortedAndFilteredInputDto input)
        {
            var query = _gatewayTypeRepository.GetAll();
            var total = query.Count();
            var result = input.Sorting != null
                ? query.OrderBy(input.Sorting).AsNoTracking().PageBy(input).ToList()
                : query.PageBy(input).ToList();
            return new PagedResultDto<GatewayTypeDto>(total, ObjectMapper.Map<List<GatewayTypeDto>>(result));

        }

        public GatewayTypeDto Create(CreateGatewayTypeDto input)
        {
            var query = _gatewayTypeRepository.GetAll().Where(gt => gt.TypeId == input.TypeId
                                                                    || gt.TypeName == input.TypeName);
            if (query.Any())
            {
                throw new ApplicationException("网关类型已存在");
            }

            var entity = ObjectMapper.Map<GatewayType>(input);
            var result = _gatewayTypeRepository.Insert(entity);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<GatewayTypeDto>(result);
        }

        public GatewayTypeDto Update(CreateGatewayTypeDto input)
        {
            var entity = _gatewayTypeRepository.Get(input.Id);
            ObjectMapper.Map(input, entity);
            var result = _gatewayTypeRepository.Update(entity);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<GatewayTypeDto>(result);
        }

        public void Delete(EntityDto<int> input)
        {
            var entity = _gatewayTypeRepository.Get(input.Id);
            _gatewayTypeRepository.Delete(entity);
        }
    }
}
