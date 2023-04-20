using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }

        /// <summary>
        /// Add a new discount
        /// </summary>
        /// <remarks>Add a new discount</remarks>
        /// <param name="body">Create a new discount</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/discount")]
        public virtual IActionResult Adddiscount([FromBody] DiscountDto body)
        {
            try
            {
                DiscountDto discount = discountRepository.CreateDiscount(body);
                return Ok(discount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a discount
        /// </summary>
        /// <remarks>delete a discount</remarks>
        /// <param name="discountId">discount id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/discount/{discountId}")]
        public virtual IActionResult Deletediscount([FromRoute][Required] long discountId, [FromHeader] string apiKey)
        {
            try
            {
                var discount = discountRepository.GetDiscountById(discountId);

                if (discount == null)
                {
                    return NotFound();
                }

                discountRepository.DeleteDiscount(discountId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find discount
        /// </summary>
        /// <remarks>Returns a discount</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/discount")]
        public virtual IActionResult Discount()
        {
            var discount = discountRepository.GetDiscount();

            if (discount == null || discount.Count == 0)
            {
                return NotFound();
            }

            return Ok(discount);
        }

        /// <summary>
        /// Find discount by ID
        /// </summary>
        /// <remarks>Returns a discount</remarks>
        /// <param name="discountId">ID of discount to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/discount/{discountId}")]
        public virtual IActionResult Getdiscount([FromRoute][Required] long discountId)
        {
            var discount = discountRepository.GetDiscountById(discountId);

            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        /// <summary>
        /// Update an existing discount
        /// </summary>
        /// <remarks>Update an existing discount by Id</remarks>
        /// <param name="body">Update an existent discount</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("/discount")]
        public virtual IActionResult Updatediscount([FromBody] DiscountDto body)
        {
            var discount = discountRepository.GetDiscountById(body.discountID);

            if (discount == null)
            {
                return NotFound();
            }

            discountRepository.UpdateDiscount(discount, body);
            return Ok(discount);
        }
    }
}
