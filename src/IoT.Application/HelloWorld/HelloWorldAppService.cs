using Abp.Application.Services;

namespace IoT.Application.HelloWorld
{
    public class HelloWorldAppService:ApplicationService
    {
        public string HelloWorld()
        {
            return "HelloWorld";
        }
    }
}
