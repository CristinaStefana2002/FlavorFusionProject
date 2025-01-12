using System.Collections.Generic;
using FlavorFusion.Models;

namespace FlavorFusion.ViewModels
{
    public class MealPlanReviewsViewModel
    {
        public IEnumerable<MealPlan> MealPlans { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public int SelectedMealPlanId { get; set; }
    }
}
