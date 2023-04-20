using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <remarks>Add a new product</remarks>
        /// <param name="body">Create a new product</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/product")]
        public virtual IActionResult Addproduct([FromBody] ProductDto body)
        {
            try
            {
                ProductDto product = productRepository.CreateProduct(body);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <remarks>delete a product</remarks>
        /// <param name="productId">product id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/product/{productId}")]
        public virtual IActionResult Deleteproduct([FromRoute][Required] long productId, [FromHeader] string apiKey)
        {
            try
            {
                var product = productRepository.GetProductById(productId);

                if (product == null)
                {
                    return NotFound();
                }

                productRepository.DeleteProduct(productId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find product by ID
        /// </summary>
        /// <remarks>Returns a product</remarks>
        /// <param name="productId">ID of product to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/product/{productId}")]
        public virtual IActionResult Getproduct([FromRoute][Required] long productId)
        {
            var product = productRepository.GetProductById(productId);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Find product
        /// </summary>
        /// <remarks>Returns a product</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [AllowAnonymous]
        [HttpGet]
        [Route("/product")]
        public virtual IActionResult Product()
        {
            var products = productRepository.GetProduct();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <remarks>Update an existing product by Id</remarks>
        /// <param name="body">Update an existent product</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("/product")]
        public virtual IActionResult Updateproduct([FromBody] ProductDto body)
        {
            var product = productRepository.GetProductById(body.productID);

            if (product == null)
            {
                return NotFound();
            }

            productRepository.UpdateProduct(product, body);
            return Ok(product);
        }
    }
}
