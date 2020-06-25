using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IoTManager.MultiTenancy.Dto;

namespace IoTManager.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

