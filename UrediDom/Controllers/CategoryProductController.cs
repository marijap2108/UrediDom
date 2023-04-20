using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class CategoryProductController : ControllerBase
    {
        private readonly ICategoryProductRepository categoryProductRepository;

        public CategoryProductController(ICategoryProductRepository categoryProductRepository)
        {
            this.categoryProductRepository = categoryProductRepository;
        }

        /// <summary>
        /// Add a new categoryProduct
        /// </summary>
        /// <remarks>Add a new categoryProduct</remarks>
        /// <param name="body">Create a new categoryProduct</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/categoryProduct")]
        public virtual IActionResult AddcategoryProduct([FromBody] CategoryProductDto body)
        {
            try
            {
                CategoryProductDto categoryProduct = categoryProductRepository.CreateCategoryProduct(body);
                return Ok(categoryProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Find categoryProduct
        /// </summary>
        /// <remarks>Returns a categoryProduct</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/categoryProduct")]
        public virtual IActionResult CategoryProduct()
        {
            var CategoryProducts = categoryProductRepository.GetCategoryProduct();

            if (CategoryProducts == null || CategoryProducts.Count == 0)
            {
                return NotFound();
            }

            return Ok(CategoryProducts);
        }

        /// <summary>
        /// Deletes a categoryProduct
        /// </summary>
        /// <remarks>delete a categoryProduct</remarks>
        /// <param name="categoryProductId">categoryProduct id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/categoryProduct/{productId}")]
        public virtual IActionResult DeleteProductId([FromRoute][Required] long productId, [FromHeader] string apiKey)
        {
            try
            {
                var categoryProduct = categoryProductRepository.GetByProductId(productId);

                if (categoryProduct == null)
                {
                    return NotFound();
                }

                categoryProductRepository.DeleteByProductId(productId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/categoryProduct/{categoryId}")]
        public virtual IActionResult DeleteCategoryId([FromRoute][Required] long categoryId, [FromHeader] string apiKey)
        {
            try
            {
                var categoryProduct = categoryProductRepository.GetByCategoryId(categoryId);

                if (categoryProduct == null)
                {
                    return NotFound();
                }

                categoryProductRepository.DeleteByCategoryId(categoryId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/categoryProduct/{categoryId}/{productId}")]
        public virtual IActionResult DeletecategoryProduct([FromRoute][Required] long productId, [FromRoute][Required] long categoryId, [FromHeader] string apiKey)
        {
            try
            {
                var categoryProduct = categoryProductRepository.GetCategoryProductByIds(productId, categoryId);

                if (categoryProduct == null)
                {
                    return NotFound();
                }

                categoryProductRepository.DeleteCategoryProduct(productId, categoryId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find categoryProduct by ID
        /// </summary>
        /// <remarks>Returns a categoryProduct</remarks>
        /// <param name="categoryProductId">ID of categoryProduct to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/categoryProduct/{categoryId}")]
        public virtual IActionResult GetByCategoryID([FromRoute][Required] long categoryId)
        {
            var categoryProduct = categoryProductRepository.GetByCategoryId(categoryId);

            if (categoryProduct == null)
            {
                return NotFound();
            }
            return Ok(categoryProduct);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/categoryProduct/{productId}")]
        public virtual IActionResult GetByProductID([FromRoute][Required] long productId)
        {
            var categoryProduct = categoryProductRepository.GetByProductId(productId);

            if (categoryProduct == null)
            {
                return NotFound();
            }
            return Ok(categoryProduct);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/categoryProduct/{categoryId}/{productId}")]
        public virtual IActionResult GetcategoryProduct([FromRoute][Required] long productId, [FromRoute][Required] long categoryId)
        {
            var categoryProduct = categoryProductRepository.GetCategoryProductByIds(productId, categoryId);

            if (categoryProduct == null)
            {
                return NotFound();
            }
            return Ok(categoryProduct);
        }
    }
}
