using System.Linq;
using Advantage.API.Data;
using Advantage.API.Dtos;
using Advantage.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Advantage.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdvantageRepository _repo;

        public CustomerController(IMapper mapper, IAdvantageRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetCustomers() 
        {
            var data = _repo.GetCustomers();

            if (!data.Any()) 
                return NotFound();
            
            return Ok(data);
        }

        [HttpGet("{id}", Name="GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var data = _repo.GetCustomer(id);

            if (data == null)
                return NoContent();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer == null) 
                return BadRequest();

            var cust = _repo.Add(customer);

            if (!_repo.SaveAll())
                return BadRequest();

            return CreatedAtRoute("GetCustomer", new {id = cust.Id }, cust);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerForUpdateDto customerForUpdateDto)
        {
            var data = _repo.GetCustomer(id);

            if (data == null)
                return NoContent();
            
            _mapper.Map(customerForUpdateDto, data);

            if (!_repo.SaveAll())
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var customer = _repo.GetCustomer(id);

            if (customer == null)
                return NotFound();

            _repo.Delete(customer);

            if (!_repo.SaveAll())
                return BadRequest();

            return NoContent();
            
        }
    }
}