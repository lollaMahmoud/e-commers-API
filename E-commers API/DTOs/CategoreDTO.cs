using System.ComponentModel.DataAnnotations;
using E_Comers_API.Models;

namespace E_Comers_API.DTOs
{
    public class CategoreDTO
    {
        [Required]
        public string Name { get; set; }

        public List<ProductDTO>? Products { get; set; }
    }
    public class CategoreDTOpost
    {
        [Required]
        public string Name { get; set; }


    }
}
