using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class TypeOfProductController : ControllerBase
    {
        private readonly ITypeOfProductRepository typeOfProductRepository;

        public TypeOfProductController(ITypeOfProductRepository typeOfProductRepository)
        {
            this.typeOfProductRepository = typeOfProductRepository;
        }

        /// <summary>
        /// Add a new typeOfProduct
        /// </summary>
        /// <remarks>Add a new typeOfProduct</remarks>
        /// <param name="body">Create a new typeOfProduct</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/typeOfProduct")]
        public virtual IActionResult AddtypeOfProduct([FromBody] TypeOfProductDto body)
        {
            try
            {
                TypeOfProductDto typeOfProduct = typeOfProductRepository.CreateTypeOfProduct(body);
                return Ok(typeOfProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a typeOfProduct
        /// </summary>
        /// <remarks>delete a typeOfProduct</remarks>
        /// <param name="typeOfProductId">typeOfProduct id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/typeOfProduct/{typeOfProductId}")]
        public virtual IActionResult DeletetypeOfProduct([FromRoute][Required] long typeOfProductId, [FromHeader] string apiKey)
        {
            try
            {
                var typeOfProduct = typeOfProductRepository.GetTypeOfProductById(typeOfProductId);

                if (typeOfProduct == null)
                {
                    return NotFound();
                }

                typeOfProductRepository.DeleteTypeOfProduct(typeOfProductId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find typeOfProduct by ID
        /// </summary>
        /// <remarks>Returns a typeOfProduct</remarks>
        /// <param name="typeOfProductId">ID of typeOfProduct to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/typeOfProduct/{typeOfProductId}")]
        public virtual IActionResult GettypeOfProduct([FromRoute][Required] long typeOfProductId)
        {
            var typeOfProduct = typeOfProductRepository.GetTypeOfProductById(typeOfProductId);

            if (typeOfProduct == null)
            {
                return NotFound();
            }
            return Ok(typeOfProduct);
        }

        /// <summary>
        /// Find typeOfProduct
        /// </summary>
        /// <remarks>Returns a typeOfProduct</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/typeOfProduct")]
        public virtual IActionResult TypeOfProduct()
        {
            var typeOfProduct = typeOfProductRepository.GetTypeOfProduct();

            if (typeOfProduct == null || typeOfProduct.Count == 0)
            {
                return NotFound();
            }

            return Ok(typeOfProduct);
        }

        /// <summary>
        /// Update an existing typeOfProduct
        /// </summary>
        /// <remarks>Update an existing typeOfProduct by Id</remarks>
        /// <param name="body">Update an existent typeOfProduct</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("/typeOfProduct")]
        public virtual IActionResult UpdateTypeOfProduct([FromBody] TypeOfProductDto body)
        {
            var typeOfProduct = typeOfProductRepository.GetTypeOfProductById(body.typeID);

            if (typeOfProduct == null)
            {
                return NotFound();
            }

            typeOfProductRepository.UpdateTypeOfProduct(typeOfProduct, body);
            return Ok(typeOfProduct);
        }
    }
}
