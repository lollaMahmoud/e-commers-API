using E_Comers_API.DTOs;

namespace E_Comers_API.Repo.CategoreRepo
{
    public interface IcategoreRepo
    {
        public List<CategoreDTO> GetByName(string name);
        public void post(CategoreDTOpost dto);
    }
}
