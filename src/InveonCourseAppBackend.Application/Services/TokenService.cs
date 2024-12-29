using Azure.Core;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Token;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Services
{
    public class TokenService:ITokenService
    {

        readonly IConfiguration _configuration;
        readonly UserManager<User> _userManager;
        public TokenService(IConfiguration configuration ,UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

     
        public TokenDto CreateToken(User user)
        {
            var jwtSection = _configuration.GetSection("JwtSettings");
          
            var accessTokenExpiration = DateTime.Now.AddMinutes(int.Parse(jwtSection["AccessTokenExpiration"]));
            //var refreshTokenExpiration = DateTime.Now.AddMinutes(int.Parse(jwtSection["RefreshTokenExpiration"]));
            var securityKey =new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSection["SecurityKey"]));

            var tokenClaims=new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString() ),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email ),
                    new Claim(JwtRegisteredClaimNames.GivenName,user.UserName ),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString() )

            };


            var userRoles=_userManager.GetRolesAsync(user).Result;
            foreach(var userRole in userRoles)
            {
                tokenClaims.Add(new Claim(ClaimTypes.Role,userRole));
            }
            SigningCredentials signingCredentials =new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: tokenClaims,
                signingCredentials: signingCredentials);

         
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
               
                AccessTokenExpiration = accessTokenExpiration,
              
            };

            return tokenDto;
        }

     
    }
}
