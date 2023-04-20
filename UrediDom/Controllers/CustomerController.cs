using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using UrediDom.Data;
using UrediDom.Models;

namespace UrediDom.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <remarks>Add a new customer</remarks>
        /// <param name="body">Create a new customer</param>
        /// <response code="200">Successful operation</response>
        /// <response code="405">Invalid input</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("/customer")]
        public virtual IActionResult Addcustomer([FromBody] CustomerDto body)
        {
            try
            {
                CustomerDto customer = customerRepository.CreateCustomer(body);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Find customer
        /// </summary>
        /// <remarks>Returns a customer</remarks>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/customer")]
        public virtual IActionResult Customer()
        {
            var customer = customerRepository.GetCustomer();

            if (customer == null || customer.Count == 0)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <remarks>delete a customer</remarks>
        /// <param name="customerId">customer id to delete</param>
        /// <param name="apiKey"></param>
        /// <response code="400">Invalid value</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("/customer/{customerId}")]
        public virtual IActionResult Deletecustomer([FromRoute][Required] long customerId, [FromHeader] string apiKey)
        {
            try
            {
                var customer = customerRepository.GetCustomerById(customerId);

                if (customer == null)
                {
                    return NotFound();
                }

                customerRepository.DeleteCustomer(customerId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Find customer by ID
        /// </summary>
        /// <remarks>Returns a customer</remarks>
        /// <param name="customerId">ID of customer to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/customer/{customerId}")]
        public virtual IActionResult Getcustomer([FromRoute][Required] long customerId)
        {
            var customer = customerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        /// <summary>
        /// Update an existing customer
        /// </summary>
        /// <remarks>Update an existing customer by Id</remarks>
        /// <param name="body">Update an existent customer</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid ID</response>
        /// <response code="404">Not found</response>
        [Authorize(Roles = "Admin, Customer")]
        [HttpPut]
        [Route("/customer")]
        public virtual IActionResult Updatecustomer([FromBody] CustomerDto body)
        {
            var customer = customerRepository.GetCustomerById(body.customerID);

            if (customer == null)
            {
                return NotFound();
            }

            customerRepository.UpdateCustomer(customer, body);
            return Ok(customer);
        }
    }
}
