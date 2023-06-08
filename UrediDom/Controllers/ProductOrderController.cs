using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("/productOrder")]
        public virtual IActionResult AddproductOrder([FromBody] ProductOrderDto body)
        {
            try
            {
                ProductOrderDto productOrder = productOrderRepository.CreateProductOrder(body);
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
        /// <param name="orderId">ID of productOrder to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/productOrder/{orderId}")]
        public virtual IActionResult GetByOrderId([FromRoute][Required] long orderId)
        {
            var productOrder = productOrderRepository.GetByOrderId(orderId);

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
        [Authorize(Roles = "Admin")]
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
