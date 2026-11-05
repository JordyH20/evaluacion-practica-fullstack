using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaFullStack.DTOs.Request;

namespace PruebaFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly Service.UserService _userService;
        public UserControllers(Service.UserService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Nombre }, user);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserRequest updatedUser)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.UpdateUserAsync(id, updatedUser);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }


    }
}
