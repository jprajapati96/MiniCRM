using CRM.Application.Models.Customer;
using CRM.Application.Repository.Interface.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRM.Application.Controllers.Customer
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> CreateCustomer(CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerRepository.AddCustomer(customerVM);
                return CreatedAtAction("GetCustomerDetail", new { customerId = customerVM.CustomerId }, customerVM);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CustomerViewModel>> GetCustomerList()
        {
            var result = await _customerRepository.GetCustomerList();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerViewModel>> GetCustomerDetail(int id)
        {
            var customerDetail = await _customerRepository.GetCustomer(id);
            if(customerDetail == null)
            {
                return NotFound();
            }
            return Ok(customerDetail);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerViewModel customerVM)
        {
            if(customerVM.CustomerId != id)
            {
                return BadRequest();
            }
            await _customerRepository.UpdateCustomer(customerVM);
            return NoContent();

        }
      
    }
}