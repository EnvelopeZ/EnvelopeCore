using Logs;
using Microsoft.AspNetCore.Mvc;
using Public;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebApi.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 测试Api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiResult TestApi()
        {
            return new ApiResult() { Result = true, Message = "测试调用成功" };
        }
    }
}
