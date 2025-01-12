using System.ComponentModel.DataAnnotations;

namespace FlavorFusion.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string MealPlanName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public MealPlan MealPlan { get; set; }
    }
}
