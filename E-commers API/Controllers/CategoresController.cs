using E_Comers_API.DTOs;
using E_Comers_API.Repo.CategoreRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoresController : ControllerBase
    {
        private readonly IcategoreRepo rep;

        public CategoresController(IcategoreRepo _rep)
        {
            rep = _rep;
        }
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var categore = rep.GetByName(name);
            if (categore == null || !categore.Any())
            {
                return NotFound(name);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { categore });
        }

        [HttpPost]
        public IActionResult Post(CategoreDTOpost dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            rep.post(dto);
            return Ok(dto);
        }
    }
}
