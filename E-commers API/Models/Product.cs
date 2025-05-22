using System.ComponentModel.DataAnnotations;

namespace E_Comers_API.Models
{
    public class Product
    {
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }
        public string Description { set; get; }
        public int Price { set; get; }
        public string Photo { set; get; }


        public int CategorieId { set; get; }
        public Categorie Categorie { set; get; }
    }
}
