using AutoMapper;
using Dapper.NET.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.NET.API.Controllers
{
    public class IdentityController : BaseController
    {
        private readonly IMapper _mapper;
        private IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityController(IMapper mapper, IConfiguration configuration, 
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUserAsync(login);

            if (user != null)
            {
                var token = GenerateJSONWebToken(user);
                response = Ok(new 
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    createdon = token.ValidFrom,
                    expires = token.ValidTo,
                    issuer = token.Issuer
                });
            }

            return response;
        }

        private JwtSecurityToken GenerateJSONWebToken(IdentityUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);
        }

        private async Task<IdentityUser> AuthenticateUserAsync(UserModel login)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, true);
            if (signInResult.Succeeded)
            {
                return await _userManager.FindByEmailAsync(login.Username);
            }

            return null;
        }
    }
}
