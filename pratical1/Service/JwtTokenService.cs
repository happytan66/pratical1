
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pratical1.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pratical1.Service
{
    public class JwtTokenService:IJwtTokenService
    {
        private readonly IConfiguration _config;

        public JwtTokenService(IConfiguration config)
        {
            _config = config;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// 

        //build the token used for authentication
        public string BuildToken(string email)
        {
            //Create a claim based on the users email,
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            //Create a key from our private key that will be used in the security algorithm
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //Credentials that are encrypted which can oni be created by our server using the private key 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // actual token that issue to the user
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Jwt:ExpireTime"])),
                signingCredentials: creds);

            //return token in the coreect format using JwtSecurityTokenHandler
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

