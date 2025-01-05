using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.User;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InveonCourseAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService,UserManager<User> userManager ,SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register (RegisterDto registerDto)
        {
            var user=new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result=await _userManager.CreateAsync(user,registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(new {Message="Registered successfuly"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto) 
        { 
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                throw new ArgumentNullException("Email and Password cannot be empty");
            }
            var user=await _userManager.FindByEmailAsync(loginDto.Email);
            if (user==null) return Unauthorized(new {Message="invalid credentials"});
            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginDto.Password, isPersistent: false, lockoutOnFailure: false); 

            if(!result.Succeeded) return Unauthorized(new { Message = "invalid credentials" });
            var accessToken = _tokenService.CreateToken(user);
            
            return Ok(new {accessToken,user});
        }

    
        
    }
}
