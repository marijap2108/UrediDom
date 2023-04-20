using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityRepository availabilityRepository;

        public AvailabilityController(IAvailabilityRepository availabilityRepository)
        {
            this.availabilityRepository = availabilityRepository;
        }

        /// <summary>
        /// Add a new availability
        /// </summary>
        /// <remarks>Add a new availability</remarks>
        /// <param name="body">Create a new availability</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Repairman")]
        [HttpPost]
        [Route("/availability")]
        public virtual IActionResult Addavailability([FromBody] AvailabilityDto body)
        {
            try
            {
                AvailabilityDto availability = availabilityRepository.CreateAvailability(body);
                return Ok(availability);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Find availability
        /// </summary>
        /// <remarks>Returns a availability</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin, Repairman")]
        [HttpGet]
        [Route("/availability")]
        public virtual IActionResult Availability()
        {
            var availabilities = availabilityRepository.GetAvailability();

            if (availabilities == null || availabilities.Count == 0)
            {
                return NotFound();
            }

            return Ok(availabilities);
        }

        /// <summary>
        /// Deletes a availability
        /// </summary>
        /// <remarks>delete a availability</remarks>
        /// <param name="availabilityId">availability id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin, Repairman")]
        [HttpDelete]
        [Route("/availability/{availabilityId}")]
        public virtual IActionResult Deleteavailability([FromRoute][Required] long availabilityId, [FromHeader] string apiKey)
        {
            try
            {
                var availability = availabilityRepository.GetAvailabilityById(availabilityId);

                if (availability == null)
                {
                    return NotFound();
                }

                availabilityRepository.DeleteAvailability(availabilityId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find availability by ID
        /// </summary>
        /// <remarks>Returns a availability</remarks>
        /// <param name="availabilityId">ID of availability to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin, Repairman")]
        [HttpGet]
        [Route("/availability/{availabilityId}")]
        public virtual IActionResult Getavailability([FromRoute][Required] long availabilityId)
        {
            var availability = availabilityRepository.GetAvailabilityById(availabilityId);

            if (availability == null)
            {
                return NotFound();
            }
            return Ok(availability);
        }

        /// <summary>
        /// Update an existing availability
        /// </summary>
        /// <remarks>Update an existing availability by Id</remarks>
        /// <param name="body">Update an existent availability</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Repairman")]
        [HttpPut]
        [Route("/availability")]
        public virtual IActionResult Updateavailability([FromBody] AvailabilityDto body)
        {
            var availability = availabilityRepository.GetAvailabilityById(body.repairmanID);

            if (availability == null)
            {
                return NotFound();
            }

            availabilityRepository.UpdateAvailability(availability, body);
            return Ok(availability);
        }
    }
}
