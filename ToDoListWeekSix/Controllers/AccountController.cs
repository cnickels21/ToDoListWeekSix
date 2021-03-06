﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDoListWeekSix.Models;
using ToDoListWeekSix.Models.DTOs;

namespace ToDoListWeekSix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ToDoUser> userManager;
        private readonly IConfiguration configuration;
        public SignInManager<ToDoUser> SignInManager { get; }

        public AccountController(UserManager<ToDoUser> userManager, SignInManager<ToDoUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.SignInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
            });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterData register)
        {
            var user = new ToDoUser
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok(new UserWithToken
            {
                UserId = user.Id,
                Token = await CreateToken(user)
            });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);

            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    return Ok(new UserWithToken
                    {
                        UserId = user.Id,
                        Token = await CreateToken(user)
                    });
                }

                await userManager.AccessFailedAsync(user);
            }

            return Unauthorized();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, UpdateUserData data)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;

            if (data.Email == null)
            {
                user.Email = user.Email;
            }
            else
            {
                user.Email = data.Email;
            }
            

            await userManager.UpdateAsync(user);

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
            });
        }

        [Authorize]
        [HttpGet("Self")]
        public async Task<IActionResult> Self()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userClaim = identity.FindFirst("UserId");
                var userId = userClaim.Value;

                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                    return Unauthorized();

                return Ok(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                });
            }

            return Unauthorized();
        }

        public async Task<string> CreateToken(ToDoUser user)
        {
            var secret = configuration["JWT:Secret"];
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);

            var principal = await SignInManager.CreateUserPrincipalAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            identity.AddClaims(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserId", user.Id),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            });

            var token = new JwtSecurityToken(
                claims: identity.Claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

    }
}