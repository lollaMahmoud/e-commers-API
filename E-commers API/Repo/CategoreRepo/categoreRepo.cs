using E_Comers_API.DTOs;
using E_Comers_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Comers_API.Repo.CategoreRepo
{
    public class categoreRepo : IcategoreRepo
    {
        private readonly AppDbContext db;
        public categoreRepo(AppDbContext _db)
        {
            db = _db;
        }

        public List<CategoreDTO> GetByName(string name)
        {
            var categore = db.categories.Include(x => x.Products).Where(x => x.Name==name).Select(x => new CategoreDTO
            {
                Name = x.Name,
                Products = x.Products.Select(p=> new ProductDTO
                {
                    Name = p.Name,
                    Photo = p.Photo,
                    Description = p.Description,
                    Price = p.Price

                }).ToList(),
            }).ToList();
            return categore;
        }

        public void post(CategoreDTOpost dto)
        {

            var categ = new Categorie()
            {
                Name = dto.Name,

            };
            db.categories.Add(categ);
            db.SaveChanges();

        }
    }
}
