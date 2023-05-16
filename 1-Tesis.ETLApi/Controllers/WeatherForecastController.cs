using _2_Tesis.Application.DesingContext;
using Microsoft.AspNetCore.Mvc;

namespace _1_Tesis.ETLApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost("LeerExcel1")]
        public async Task<IActionResult> LeerExcel1(IFormFile formFile)
        {
            await FactoryContext.LeerExcel1ContextManager.LeerExcel1(formFile);
            return Ok();
        }

        [HttpPost("LeerExcel2")]
        public async Task<IActionResult> LeerExcel2(IFormFile formFile)
        {
            await FactoryContext.LeerExcel1ContextManager.LeerExcel2(formFile);
            return Ok();
        }

        [HttpPost("LeerExcel3")]
        public async Task<IActionResult> LeerExcel3(IFormFile formFile)
        {
            await FactoryContext.LeerExcel1ContextManager.LeerExcel3(formFile);
            return Ok();
        }

        [HttpPost("LeerExcel4")]
        public async Task<IActionResult> LeerExcel4(IFormFile formFile)
        {
            await FactoryContext.LeerExcel1ContextManager.LeerExcel4(formFile);
            return Ok();
        }
    }
}