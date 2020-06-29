using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using IoT.Core;
using L._52ABP.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace IoT.Application.DeviceAppService
{
    public class TagAppService:ApplicationService,ITagAppService
    {
        private readonly IRepository<Tag, int> _tagRepository;

        public TagAppService(IRepository<Tag, int> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public TagDto Get(EntityDto<int> input)
        {
            var entity = _tagRepository.Get(input.Id);
            return ObjectMapper.Map<TagDto>(entity);
        }

        public PagedResultDto<TagDto> GetAll(PagedSortedAndFilteredInputDto input)
        {
            var query = _tagRepository.GetAll();
            var total = query.Count();
            var result = input.Sorting != null
                ? query.OrderBy(input.Sorting).AsNoTracking().PageBy(input).ToList()
                : query.PageBy(input).ToList();
            return new PagedResultDto<TagDto>(total, ObjectMapper.Map<List<TagDto>>(result));
        }

        public TagDto Create(CreateTagDto input)
        {
            var tagQuery = _tagRepository.GetAll().Where(t => t.TagName == input.TagName);
            if (tagQuery.Any())
            {
                throw new ApplicationException("Tag已存在");
            }

            var tag = ObjectMapper.Map<Tag>(tagQuery.FirstOrDefault());
            var result = _tagRepository.Insert(tag);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<TagDto>(result);

        }

        public TagDto Update(CreateTagDto input)
        {
            var entity = _tagRepository.Get(input.Id);
            ObjectMapper.Map(input, entity);
            var result = _tagRepository.Update(entity);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<TagDto>(result);
        }

        public void Delete(EntityDto<int> input)
        {
            var entity = _tagRepository.Get(input.Id);
            _tagRepository.Delete(entity);
        }
    }
}
