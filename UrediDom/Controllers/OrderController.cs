using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Stripe;
using Stripe.FinancialConnections;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUserRepository userRepository;
        private readonly IProductOrderRepository productOrderRepository;

        public OrderController(IOrderRepository orderRepository, IUserRepository userRepository, IProductOrderRepository productOrderRepository)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.productOrderRepository = productOrderRepository;
        }

        /// <summary>
        /// Add a new order and stripe
        /// </summary>
        /// <remarks>Add a new order</remarks>
        /// <param name="body">Create a new order</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("/order")]
        public virtual async Task<IActionResult> Addorder([FromBody] List<ProductOrderDto> body)
        {
            OrderDto order = new OrderDto();

            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);

            var jwt = values.ToString();

            if (jwt.Contains("Bearer"))
            {
                jwt = jwt.Replace("Bearer", "").Trim();

                var handler = new JwtSecurityTokenHandler();

                JwtSecurityToken token = new JwtSecurityToken();

                try
                {
                    token = handler.ReadJwtToken(jwt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                var user = userRepository.GetUserByEmail(token!.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                order.customerID = user?.userID;
            }


            order.amount = (int?)body.Sum(product => product.quantity * product.price);

            try
            {
                order = orderRepository.CreateOrder(order);

                body.ForEach(productOrder =>
                {
                    productOrder.orderID = order.orderID;
                    productOrderRepository.CreateProductOrder(productOrder);
                });

                StripeConfiguration.ApiKey = "sk_test_51NEXvEERmXeMfmnkriY1UFLsNlHDrhlm3QWmkgVWeHGKawOjFRfJOx3wTHqigjLqUi0mAbvGycMlMyNLdMFNraBi00m9HrwXen";

                var options = new PaymentIntentCreateOptions
                {
                    Amount = order.amount,
                    Currency = "rsd",
                    PaymentMethodTypes = new List<string> { "card" },
                    Metadata = new Dictionary<string, string> { { "orderID", order.orderID.ToString() } }
                };
                var service = new PaymentIntentService();
                var intent = await service.CreateAsync(options);

                return Ok(new { clientSecret = intent.ClientSecret });
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
