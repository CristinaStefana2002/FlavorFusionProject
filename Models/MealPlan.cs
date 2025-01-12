using System.ComponentModel.DataAnnotations;

namespace FlavorFusion.Models
{
    public class MealPlan
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string UserName { get; set; } 
    }
}
