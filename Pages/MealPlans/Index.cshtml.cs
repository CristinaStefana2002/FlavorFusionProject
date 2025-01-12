using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlavorFusion.Data;
using FlavorFusion.Models;

namespace FlavorFusion.Pages.MealPlans
{
    public class IndexModel : PageModel
    {
        private readonly FlavorFusion.Data.FlavorFusionContext _context;

        public IndexModel(FlavorFusion.Data.FlavorFusionContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlan { get; set; } = default!;
        public IList<Review> Reviews { get; set; } = new List<Review>();

        [BindProperty(SupportsGet = true)]
        public int? SelectedMealPlanId { get; set; }

        public async Task OnGetAsync()
        {
            MealPlan = await _context.MealPlan
                .Include(mp => mp.Reviews)
                .ToListAsync();

            if (SelectedMealPlanId.HasValue)
            {
                Reviews = await _context.Review
                    .Where(r => r.MealPlan.Id == SelectedMealPlanId.Value)
                    .ToListAsync();
            }
        }
    }
}
