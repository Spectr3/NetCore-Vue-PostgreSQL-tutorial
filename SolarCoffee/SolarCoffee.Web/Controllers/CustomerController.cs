using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Data.Models;
using SolarCoffee.Services.Customer;
using SolarCoffee.Web.Serialisation;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost("/api/customer")]
        public ActionResult CreateCustomer([FromBody] CustomerModel customer)
        {
            _logger.LogInformation("Creating a customer");
            customer.CreatedOn = DateTime.UtcNow;
            customer.UpdatedOn = DateTime.UtcNow;
            customer.PrimaryAddress.CreatedOn = DateTime.UtcNow;
            customer.PrimaryAddress.UpdatedOn = DateTime.UtcNow;
            var customerData = CustomerMapper.SerialiseCustomer(customer);
            var newCustomer = _customerService.CreateCustomer(customerData);
            return Ok(newCustomer);
        }

        [HttpGet("/api/customer")]
        public ActionResult GetCustomers()
        {
            _logger.LogInformation("Getting customers");
            var customers = _customerService.GetAllCustomers();

            var customerModels = customers.Select(customer => CustomerMapper.SerialiseCustomer(customer))
                .OrderByDescending(customer => customer.CreatedOn)
                .ToList();
            return Ok(customerModels);
        }

        [HttpDelete("/api/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation($"Deleting customer: {id}");
            var response = _customerService.DeleteCustomer(id);
            return Ok(response);
        }
    }
}