using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IoTManager.Configuration.Dto;

namespace IoTManager.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IoTManagerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
