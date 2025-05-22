using E_Comers_API.DTOs;
using E_Comers_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Comers_API.Repo.ProductsRepo
{
    public class ProductsRepo : IProductRepo
    {
        private readonly AppDbContext db;
        public ProductsRepo(AppDbContext _db)
        {
            db = _db;
        }
        public List<ProductDTOpost> getAll()
        {
            var product = db.products.Include(x => x.Categorie).Select(x => new ProductDTOpost
            {
                CategoreDTOpost = new CategoreDTOpost()
                {
                    Name = x.Categorie.Name,
                },
                Name = x.Name,
                Photo = x.Photo,
                Description = x.Description,
                Price = x.Price,

            }).ToList();
            return product;
        }

        public List<ProductDTOpost> getById(int id)
        {
            var product = db.products.Where(x => x.Id == id).Include(x => x.Categorie).Select(x => new ProductDTOpost
            {
                CategoreDTOpost = new CategoreDTOpost()
                {
                    Name = x.Categorie.Name,
                },
                Name = x.Name,
                Photo = x.Photo,
                Description = x.Description,
                Price = x.Price,

            }).ToList();
            return product;
        }

        public void post(ProductDTOpost dto)
        {
            var categ = db.categories.FirstOrDefault(x => x.Name.ToLower() == dto.CategoreDTOpost.Name.ToLower());
            if (categ == null)
            {
                throw new Exception("no categore with that name");
            }
            var product = new Product()
            {

                
                Name = dto.Name,
                Photo = dto.Photo,
                Description = dto.Description,
                Price = dto.Price,
                 Categorie = categ,
            };
            db.products.Add(product);
            db.SaveChanges();
        }
    }
}
