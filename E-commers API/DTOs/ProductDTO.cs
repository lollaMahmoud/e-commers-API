using System.ComponentModel.DataAnnotations;

namespace E_Comers_API.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { set; get; }
        public string Description { set; get; }
        public int Price { set; get; }
        public string Photo { set; get; }



    }
    public class ProductDTOpost
    {
        [Required]
        public string Name { set; get; }
        public string Description { set; get; }
        public int Price { set; get; }
        public string Photo { set; get; }
        public CategoreDTOpost CategoreDTOpost { set; get; }
    }
}
