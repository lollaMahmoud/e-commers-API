using E_Comers_API.DTOs;
using E_Comers_API.Repo.ProductsRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo rep;
        public ProductsController(IProductRepo _rep)
        {
            rep = _rep;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = rep.getAll();
            if (products == null || !products.Any())
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { products });

        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var products = rep.getById(id);
            if (products == null || !products.Any())
            {
                return NotFound(id);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { products });

        }

        [HttpPost]
        public IActionResult Post(ProductDTOpost dto)
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
