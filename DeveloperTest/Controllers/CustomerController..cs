using System;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerService.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(BaseCustomerModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || model.Name.Trim().Length < 5)
            {
                return BadRequest("Name cannot less than 5 characters");
            }
            if (string.IsNullOrEmpty(model.Type) || 
                !(model.Type.Equals("Large", StringComparison.CurrentCultureIgnoreCase) ||
                model.Type.Equals("Small", StringComparison.CurrentCultureIgnoreCase))
                )
            {
                return BadRequest("Type should be Large or Small");
            }

            var customer = customerService.CreateCustomer(model);

            return Created($"customer/{customer.CustomerId}", customer);
        }
    }
}