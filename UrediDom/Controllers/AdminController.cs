using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        /// <summary>
        /// Add a new admin
        /// </summary>
        /// <remarks>Add a new admin</remarks>
        /// <param name="body">Create a new admin</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/admin")]
        public virtual IActionResult Addadmin([FromBody] AdminDto body)
        {
            try
            {
                AdminDto admin = adminRepository.CreateAdmin(body);
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Find admin
        /// </summary>
        /// <remarks>Returns a admin</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/admin")]
        public virtual IActionResult Admin()
        {
            var admins = adminRepository.GetAdmin();

            if (admins == null || admins.Count == 0)
            {
                return NotFound();
            }

            return Ok(admins);
        }

        /// <summary>
        /// Deletes a admin
        /// </summary>
        /// <remarks>delete a admin</remarks>
        /// <param name="adminId">admin id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/admin/{adminId}")]
        public virtual IActionResult Deleteadmin([FromRoute][Required] long adminId, [FromHeader] string apiKey)
        {
            try
            {
                var admin = adminRepository.GetAdminById(adminId);

                if (admin == null)
                {
                    return NotFound();
                }

                adminRepository.DeleteAdmin(adminId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find admin by ID
        /// </summary>
        /// <remarks>Returns a admin</remarks>
        /// <param name="adminId">ID of admin to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/admin/{adminId}")]
        public virtual IActionResult Getadmin([FromRoute][Required] long adminId)
        {
            var admin = adminRepository.GetAdminById(adminId);

            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
    }
}
