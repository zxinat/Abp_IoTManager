using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IoTManager.Roles.Dto;
using IoTManager.Users.Dto;

namespace IoTManager.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
