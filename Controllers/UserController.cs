using KandaIdea_Task.Application.Shared;
using KandaIdea_Task.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KandaIdea_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion
        #region Ctor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        #region Methods
        [HttpGet]
        public async Task<IActionResult> GetAllUsersPaginated([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            PaginationParams pagination = new PaginationParams() { PageNumber = pageNumber , PageSize = pageSize };
            var result =  await _userService.GetAllAsync(pagination);
            return Ok(result);
        }
        #endregion

    }
}
