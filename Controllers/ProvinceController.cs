using DNTPersianUtils.Core.IranCities;
using KandaIdea_Task.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KandaIdea_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        #region Fields
        private readonly IProvinceService _provinceService;
        #endregion
        #region Ctor
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> ShowProvincesOfIran()
        {
            return Ok(_provinceService.ShowProvinceWithCities());
        }
    }
}
