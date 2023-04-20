using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository productGroupRepository;

        public ProductGroupController(IProductGroupRepository productGroupRepository)
        {
            this.productGroupRepository = productGroupRepository;
        }

        /// <summary>
        /// Add a new productGroup
        /// </summary>
        /// <remarks>Add a new productGroup</remarks>
        /// <param name="body">Create a new productGroup</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/productGroup")]
        public virtual IActionResult AddproductGroup([FromBody] ProductGroupDto body)
        {
            try
            {
                ProductGroupDto productGroup = productGroupRepository.CreateProductGroup(body);
                return Ok(productGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a productGroup
        /// </summary>
        /// <remarks>delete a productGroup</remarks>
        /// <param name="productGroupId">productGroup id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/productGroup/{productGroupId}")]
        public virtual IActionResult DeleteproductGroup([FromRoute][Required] long productGroupId, [FromHeader] string apiKey)
        {
            try
            {
                var productGroup = productGroupRepository.GetProductGroupById(productGroupId);

                if (productGroup == null)
                {
                    return NotFound();
                }

                productGroupRepository.DeleteProductGroup(productGroupId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find productGroup by ID
        /// </summary>
        /// <remarks>Returns a productGroup</remarks>
        /// <param name="productGroupId">ID of productGroup to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/productGroup/{productGroupId}")]
        public virtual IActionResult GetproductGroup([FromRoute][Required] long productGroupId)
        {
            var productGroup = productGroupRepository.GetProductGroupById(productGroupId);

            if (productGroup == null)
            {
                return NotFound();
            }
            return Ok(productGroup);
        }

        /// <summary>
        /// Find productGroup
        /// </summary>
        /// <remarks>Returns a productGroup</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/productGroup")]
        public virtual IActionResult ProductGroup()
        {
            var productGroup = productGroupRepository.GetProductGroup();

            if (productGroup == null || productGroup.Count == 0)
            {
                return NotFound();
            }

            return Ok(productGroup);
        }

        /// <summary>
        /// Update an existing productGroup
        /// </summary>
        /// <remarks>Update an existing productGroup by Id</remarks>
        /// <param name="body">Update an existent productGroup</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("/productGroup")]
        public virtual IActionResult UpdateproductGroup([FromBody] ProductGroupDto body)
        {
            var productGroup = productGroupRepository.GetProductGroupById(body.groupID);

            if (productGroup == null)
            {
                return NotFound();
            }

            productGroupRepository.UpdateProductGroup(productGroup, body);
            return Ok(productGroup);
        }
    }
}
