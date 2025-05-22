using System.ComponentModel.DataAnnotations;

namespace E_Comers_API.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
