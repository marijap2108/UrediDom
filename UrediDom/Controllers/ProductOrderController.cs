using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class ProductOrderController : ControllerBase
    {
        private readonly IProductOrderRepository productOrderRepository;

        public ProductOrderController(IProductOrderRepository productOrderRepository)
        {
            this.productOrderRepository = productOrderRepository;
        }

        /// <summary>
        /// Add a new productOrder
        /// </summary>
        /// <remarks>Add a new productOrder</remarks>
        /// <param name="body">Create a new productOrder</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/productOrder")]
        public virtual IActionResult AddproductOrder([FromBody] ProductOrder body)
        {
            try
            {
                ProductOrder productOrder = productOrderRepository.CreateProductOrder(body);
                return Ok(productOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Find productOrder by ID
        /// </summary>
        /// <remarks>Returns a productOrder</remarks>
        /// <param name="productOrderId">ID of productOrder to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("/productOrder/{productId}")]
        public virtual IActionResult GetByProductID([FromRoute][Required] long productId)
        {
            var productOrder = productOrderRepository.GetByProductId(productId);

            if (productOrder == null)
            {
                return NotFound();
            }
            return Ok(productOrder);
        }

        /// <summary>
        /// Find productOrder
        /// </summary>
        /// <remarks>Returns a productOrder</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        [Route("/productOrder")]
        public virtual IActionResult ProductOrder()
        {
            var productOrder = productOrderRepository.GetProductOrder();

            if (productOrder == null || productOrder.Count == 0)
            {
                return NotFound();
            }

            return Ok(productOrder);
        }
    }
}
