using System.Threading.Tasks;
using Abp.Application.Services;
using IoTManager.Authorization.Accounts.Dto;

namespace IoTManager.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
