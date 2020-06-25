using System.Threading.Tasks;
using Abp.Application.Services;
using IoTManager.Sessions.Dto;

namespace IoTManager.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
