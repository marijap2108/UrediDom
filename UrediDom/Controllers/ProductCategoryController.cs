using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        /// <summary>
        /// Add a new productCategory
        /// </summary>
        /// <remarks>Add a new productCategory</remarks>
        /// <param name="body">Create a new productCategory</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/productCategory")]
        public virtual IActionResult AddproductCategory([FromBody] ProductCategoryDto body)
        {
            try
            {
                ProductCategoryDto category = productCategoryRepository.CreateProductCategory(body);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a productCategory
        /// </summary>
        /// <remarks>delete a productCategory</remarks>
        /// <param name="productCategoryId">productCategory id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/productCategory/{productCategoryId}")]
        public virtual IActionResult DeleteproductCategory([FromRoute][Required] long productCategoryId, [FromHeader] string apiKey)
        {
            try
            {
                var category = productCategoryRepository.GetProductCategoryById(productCategoryId);

                if (category == null)
                {
                    return NotFound();
                }

                productCategoryRepository.DeleteProductCategory(productCategoryId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find productCategory by ID
        /// </summary>
        /// <remarks>Returns a productCategory</remarks>
        /// <param name="productCategoryId">ID of productCategory to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/productCategory/{productCategoryId}")]
        public virtual IActionResult GetproductCategory([FromRoute][Required] long productCategoryId)
        {
            var category = productCategoryRepository.GetProductCategoryById(productCategoryId);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        /// <summary>
        /// Find productCategory
        /// </summary>
        /// <remarks>Returns a productCategory</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/productCategory")]
        public virtual IActionResult ProductCategory()
        {
            var category = productCategoryRepository.GetProductCategory();

            if (category == null || category.Count == 0)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// Update an existing productCategory
        /// </summary>
        /// <remarks>Update an existing productCategory by Id</remarks>
        /// <param name="body">Update an existent productCategory</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("/productCategory")]
        public virtual IActionResult UpdateproductCategory([FromBody] ProductCategoryDto body)
        {
            var category = productCategoryRepository.GetProductCategoryById(body.categoryID);

            if (category == null)
            {
                return NotFound();
            }

            productCategoryRepository.UpdateProductCategory(category, body);
            return Ok(category);
        }
    }
}
