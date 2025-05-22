using E_Comers_API.DTOs;

namespace E_Comers_API.Repo.ProductsRepo
{
    public interface IProductRepo
    {
        public List<ProductDTOpost> getAll();
        public List<ProductDTOpost> getById(int id);
        public void post(ProductDTOpost dto);


    }
}
