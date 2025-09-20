using AutoMapper;
using IPTMidtermexam.Data.Repositories;
using IPTMidtermexam.DTO.CustomerDTO;
using IPTMidtermexam.Model.Domain;
using IPTMidtermexam.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPTMidtermexam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDTOs);
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CreateCustomerDTO createCustomerDTO)
        {
            var customer = _mapper.Map<Customer>(createCustomerDTO);
            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveAsync();

            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerID }, customerDTO);
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerDTO updateCustomerDTO)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCustomerDTO, customer);
            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/customers/5 (soft delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.IsDeleted = true; // Mark as deleted instead of removing
            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.SaveAsync();

            return NoContent();
        }
    }
}
