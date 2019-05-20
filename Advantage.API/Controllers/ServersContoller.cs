using System.Linq;
using Advantage.API.Data;
using Advantage.API.Dtos;
using Advantage.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Advantage.API.Controllers
{
    [Route("api/[controller]")]
    public class ServersController : Controller
    {
        IAdvantageRepository _repo;

        public ServersController(IAdvantageRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetServers()
        {
            var servers = _repo.GetServers();

            if (!servers.Any())
                return NotFound();

            return Ok(servers);
        }

        [HttpGet("changeStatus/{id}")]
        public IActionResult ChangeServerStatus(int id)
        {
            _repo.ChangeServerStatus(id);

            if (!_repo.SaveAll())
                return BadRequest();

            return Ok();
        }
    }
}