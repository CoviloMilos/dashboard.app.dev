using System;
using System.Linq;
using Advantage.API.Data;
using Advantage.API.Dtos;
using Advantage.API.Helpers;
using Advantage.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Advantage.API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IAdvantageRepository _repo;
        private readonly IMapper _mapper;

        public OrdersController(IAdvantageRepository repo, IMapper mapper)  
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult GetOrders(int pageIndex, int pageSize) 
        {
            var orders = _repo.GetOrders();
            
            if (!orders.Any())
                return NotFound();

            var page = new PaginatedResponse<Order>(orders, pageIndex, pageSize);

            var totalCount = orders.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPages
            };

            return Ok(response);
        }

        [HttpGet("{id}", Name="GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var order = _repo.GetOrder(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderForCreateDto orderForCreateDto) 
        {
            if (orderForCreateDto == null)
                return BadRequest();
                
            var result = _repo.CreateOrder(orderForCreateDto);

            if (!_repo.SaveAll())
                return BadRequest();

            return CreatedAtRoute("GetOrder", new {id = result.Id}, result);
        }
    }
}