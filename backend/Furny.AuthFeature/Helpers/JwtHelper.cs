using AspNetCore.Identity.MongoDbCore.Models;
using Furny.Model;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public static class JwtHelper
    {
        private const string RoleClaimType = "role";
        private const string IdClaimType = "id";

        public static string GenerateToken(this IConfiguration configuration, MongoIdentityUser<ObjectId> user, ApplicationRole role)
        {
            var claims = new List<Claim>
            {
                new Claim(RoleClaimType, role.Name),
                new Claim(IdClaimType, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
