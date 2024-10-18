using Manager.CutsomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Model.CustomerModel;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomer()
        {
            return Ok(_customerService.GetAllCustomer());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerService.UpdateCustomer(id, customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult CustomerStudent(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}