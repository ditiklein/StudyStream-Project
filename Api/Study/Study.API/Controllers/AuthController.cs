using Microsoft.AspNetCore.Mvc;
using Study.Core.Interface.IntarfaceService;
using Study.Service;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IUserService _userService;


    public AuthController(AuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }


    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
    {
        var roleName =  _userService.Authenticate(model.Email, model.Password);
        var user = _userService.GetUserByEmail(model.Email);
        if (roleName == "Admin")
        {
            var token = _authService.GenerateJwtToken(model.Email, new[] { "Admin" });
            return Ok(new { Token = token,User=user});
        }
      
        else if (roleName == "User")
        {
            var token = _authService.GenerateJwtToken(model.Email, new[] { "User" });
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}

public class LoginModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

