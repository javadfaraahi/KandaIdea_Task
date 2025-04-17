using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Application.Shared;
using KandaIdea_Task.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KandaIdea_Task.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

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
        public async Task<IActionResult> GetAllUsersPaginated([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            PaginationParams pagination = new PaginationParams() { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _userService.GetAllAsync(pagination);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> SearchUsersByName([FromQuery] string searchParameter)
        {
            if (searchParameter == null)
            {
                return BadRequest("search parameter is empty");
            }
            var result = await _userService.SearchByFullName(searchParameter);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> SearchUsersByPhoneNumber([FromQuery] string searchParameter)
        {
            if (searchParameter == null)
            {
                return BadRequest("search parameter is empty");
            }
            var result = await _userService.SearchByPhoneNumber(searchParameter);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> SearchUsersByCity([FromQuery] string searchParameter)
        {
            if (searchParameter == null)
            {
                return BadRequest("search parameter is empty");
            }
            var result = await _userService.SearchByCity(searchParameter);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> SearchUsersByProvince([FromQuery] string searchParameter)
        {
            if (searchParameter == null)
            {
                return BadRequest("search parameter is empty");
            }
            var result = await _userService.SearchByProvince(searchParameter);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserById([FromQuery] int Id)
        {
            if (Id == null)
            {
                return BadRequest("Id is empty");
            }
            await _userService.Delete(Id);
            return Ok("User deleted!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUsersById([FromQuery]List<int> Ids)
        {
            if (Ids == null)
            {
                return BadRequest("Id List is empty");
            }
            await _userService.DeleteRange(Ids);
            return Ok("Users deleted!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto dto)
        {
            try
            {
                return Ok( await _userService.UpdateUser(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            try
            {
                return Ok(await _userService.CreateUser(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
