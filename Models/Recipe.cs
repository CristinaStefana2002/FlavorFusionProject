using System.ComponentModel.DataAnnotations.Schema;

namespace FlavorFusion.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public ICollection<RecipeCategory>? RecipeCategories { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }


    }
}
