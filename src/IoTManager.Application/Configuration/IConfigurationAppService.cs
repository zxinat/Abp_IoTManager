using System.Threading.Tasks;
using IoTManager.Configuration.Dto;

namespace IoTManager.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
