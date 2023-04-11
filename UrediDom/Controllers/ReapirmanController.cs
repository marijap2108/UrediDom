using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class ReapirmanController : ControllerBase
    {
        private readonly IRepairmanRepository reapirmanRepository;

        public ReapirmanController(IRepairmanRepository reapirmanRepository)
        {
            this.reapirmanRepository = reapirmanRepository;
        }

        /// <summary>
        /// Add a new reapirman
        /// </summary>
        /// <remarks>Add a new reapirman</remarks>
        /// <param name="body">Create a new reapirman</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/reapirman")]
        public virtual IActionResult Addreapirman([FromBody] Repairman body)
        {
            try
            {
                Reapirman reapirman = reapirmanRepository.CreateRepairman(body);
                return Ok(reapirman);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a reapirman
        /// </summary>
        /// <remarks>delete a reapirman</remarks>
        /// <param name="reapirmanId">reapirman id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [HttpDelete]
        [Route("/reapirman/{reapirmanId}")]
        public virtual IActionResult Deletereapirman([FromRoute][Required] long reapirmanId, [FromHeader] string apiKey)
        {
            try
            {
                var reapirman = reapirmanRepository.GetRepairmanById(reapirmanId);

                if (reapirman == null)
                {
                    return NotFound();
                }

                reapirmanRepository.DeleteRepairman(reapirmanId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find reapirman by ID
        /// </summary>
        /// <remarks>Returns a reapirman</remarks>
        /// <param name="reapirmanId">ID of reapirman to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        [Route("/reapirman/{reapirmanId}")]
        public virtual IActionResult Getreapirman([FromRoute][Required] long reapirmanId)
        {
            var reapirman = reapirmanRepository.GetRepairmanById(reapirmanId);

            if (reapirman == null)
            {
                return NotFound();
            }
            return Ok(reapirman);
        }

        /// <summary>
        /// Find reapirman
        /// </summary>
        /// <remarks>Returns a reapirman</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        [Route("/reapirman")]
        public virtual IActionResult Reapirman()
        {
            var reapirmans = reapirmanRepository.GetRepairman();

            if (reapirmans == null || reapirmans.Count == 0)
            {
                return NotFound();
            }

            return Ok(reapirmans);
        }
    }
}
