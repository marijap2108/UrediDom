using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration config;


        public UserController(IUserRepository userRepository, IConfiguration config)
        {
            this.userRepository = userRepository;
            this.config = config;

        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <remarks>delete a user</remarks>
        /// <param name="userId">user id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/user/{userId}")]
        public virtual IActionResult Deleteuser([FromRoute][Required] long userId, [FromHeader] string apiKey)
        {
            try
            {
                var user = userRepository.GetUserById(userId);

                if (user == null)
                {
                    return NotFound();
                }

                userRepository.DeleteUser(userId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find user by ID
        /// </summary>
        /// <remarks>Returns a user</remarks>
        /// <param name="userId">ID of user to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/user/{userId}")]
        public virtual IActionResult Getuser([FromRoute][Required] long userId)
        {
            var user = userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <remarks>Update an existing user by Id</remarks>
        /// <param name="body">Update an existent user</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize]
        [HttpPut]
        [Route("/user")]
        public virtual IActionResult Updateuser([FromBody] UserDto body)
        {
            var user = userRepository.GetUserById(body.userID);

            if (user == null)
            {
                return NotFound();
            }

            userRepository.UpdateUser(user, body);
            return Ok(user);
        }

        /// <summary>
        /// Find user
        /// </summary>
        /// <remarks>Returns a user</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/users")]
        public new virtual IActionResult Users()
        {
            var user = userRepository.GetUser();

            if (user == null || user.Count == 0)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpGet]
        [Route("/user")]
        public new virtual IActionResult User([FromHeader] string autherization)
        {
            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);

            var jwt = values.ToString();
            jwt = jwt.Replace("Bearer", "").Trim();

            var handler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = handler.ReadJwtToken(jwt);

            var user = userRepository.GetUserByEmail(token.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// CREATE ACCOUNT
        /// REGISTRATION
        [AllowAnonymous]
        [HttpPost]
        [Route("/register")]
        public new virtual IActionResult Register([FromBody] UserDto body)
        {
            body.role = "customer";
            try
            {
                UserDto user = userRepository.CreateUser(body);

                var token = userRepository.GenerateToken(user, config);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// LOGIN 
        [AllowAnonymous]
        [HttpPost]
        [Route("/login")]
        public new virtual IActionResult Login([FromBody] LoginDto body)
        {
            try
            {
                UserDto? user = userRepository.LoginUser(body);

                if (user == null)
                {
                    return NotFound();
                }

                var token = userRepository.GenerateToken(user, config);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
