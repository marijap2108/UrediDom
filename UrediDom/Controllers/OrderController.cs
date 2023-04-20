using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        /// <summary>
        /// Add a new order
        /// </summary>
        /// <remarks>Add a new order</remarks>
        /// <param name="body">Create a new order</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("/order")]
        public virtual IActionResult Addorder([FromBody] OrderDto body)
        {
            try
            {
                OrderDto order = orderRepository.CreateOrder(body);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a order
        /// </summary>
        /// <remarks>delete a order</remarks>
        /// <param name="orderId">order id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/order/{orderId}")]
        public virtual IActionResult Deleteorder([FromRoute][Required] long orderId, [FromHeader] string apiKey)
        {
            try
            {
                var order = orderRepository.GetOrderById(orderId);

                if (order == null)
                {
                    return NotFound();
                }

                orderRepository.DeleteOrder(orderId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find order by ID
        /// </summary>
        /// <remarks>Returns a order</remarks>
        /// <param name="orderId">ID of order to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/order/{orderId}")]
        public virtual IActionResult Getorder([FromRoute][Required] long orderId)
        {
            var order = orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        /// <summary>
        /// Find order
        /// </summary>
        /// <remarks>Returns a order</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/order")]
        public virtual IActionResult Order()
        {
            var order = orderRepository.GetOrder();

            if (order == null || order.Count == 0)
            {
                return NotFound();
            }

            return Ok(order);
        }

        /// <summary>
        /// Update an existing order
        /// </summary>
        /// <remarks>Update an existing order by Id</remarks>
        /// <param name="body">Update an existent order</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("/order")]
        public virtual IActionResult Updateorder([FromBody] OrderDto body)
        {
            var order = orderRepository.GetOrderById(body.orderID);

            if (order == null)
            {
                return NotFound();
            }

            orderRepository.UpdateOrder(order, body);
            return Ok(order);
        }
    }
}
