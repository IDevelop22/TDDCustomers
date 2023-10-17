using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TDDCustomers.API.Services;

namespace TDDCustomers.API.Controllers;

[ApiController]
[Route("[controller]")] 
public class UsersController : ControllerBase
{
    private readonly IUserSevice _userSevice;

    public UsersController(IUserSevice userSevice)
    {
        _userSevice = userSevice;
    }

    [HttpGet(Name = "GetAllUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await _userSevice.GetAllUsers();
        if (users.Any()) {
            return Ok(users);
        }
        return NotFound();
    }
}
