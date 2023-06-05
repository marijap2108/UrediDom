using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Add a new reservation
        /// </summary>
        /// <remarks>Add a new reservation</remarks>
        /// <param name="body">Create a new reservation</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("/reservation")]
        public virtual IActionResult Addreservation([FromBody] ReservationDto body)
        {
            if (DateTime.Compare((DateTime)body.startDate, (DateTime)body.endDate) > 0)
            {
                return BadRequest();
            }

            try
            {
                ReservationDto reservation = reservationRepository.CreateReservation(body);
                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a reservation
        /// </summary>
        /// <remarks>delete a reservation</remarks>
        /// <param name="reservationId">reservation id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/reservation/{reservationId}")]
        public virtual IActionResult Deletereservation([FromRoute][Required] long reservationId, [FromHeader] string apiKey)
        {
            try
            {
                var reservation = reservationRepository.GetReservationById(reservationId);

                if (reservation == null)
                {
                    return NotFound();
                }

                reservationRepository.DeleteReservation(reservationId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find reservation by ID
        /// </summary>
        /// <remarks>Returns a reservation</remarks>
        /// <param name="reservationId">ID of reservation to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/reservation/{reservationId}")]
        public virtual IActionResult Getreservation([FromRoute][Required] long reservationId)
        {
            var reservation = reservationRepository.GetReservationById(reservationId);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        /// <summary>
        /// Find reservation
        /// </summary>
        /// <remarks>Returns a reservation</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/reservation")]
        public virtual IActionResult Reservation()
        {
            var reservation = reservationRepository.GetReservation();

            if (reservation == null || reservation.Count == 0)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        /// <summary>
        /// Update an existing reservation
        /// </summary>
        /// <remarks>Update an existing reservation by Id</remarks>
        /// <param name="body">Update an existent reservation</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("/reservation")]
        public virtual IActionResult Updatereservation([FromBody] ReservationDto body)
        {
            var reservation = reservationRepository.GetReservationById(body.reservationID);

            if (reservation == null)
            {
                return NotFound();
            }

            reservationRepository.UpdateReservation(reservation, body);
            return Ok(reservation);
        }
    }
}
