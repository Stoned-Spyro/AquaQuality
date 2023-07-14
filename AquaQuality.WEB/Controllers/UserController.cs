using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using AquaQuality.DAL.Interfaces;
using AquaQuality.DAL.Models;
using AquaQuality.DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace AquaQuality.WEB.Controllers
{
    [Route("api/users")]
    [AllowAnonymous]
    public class UserController : MainController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegisterAsync (RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Incorect password. It shoul contain 1 upper case letter, 1 digit and 1 symbol");
            }
        }
        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            SetRefreshTokenInCookie(result.RefreshToken);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            if(!users.Any()) return NotFound();
       
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }
        [Authorize]
        [HttpGet("tokens/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRefreshTokensByUID(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user.RefreshTokens);
        }

        [HttpPost("revoke-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            var response = _userService.RevokeToken(token);

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }
        [HttpPost("refresh-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken ()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var responce = await _userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(responce.RefreshToken))
            {
                SetRefreshTokenInCookie(responce.RefreshToken);
            }
            return Ok(responce);
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(3)
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
