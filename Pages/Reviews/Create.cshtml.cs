using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlavorFusion.Data;
using FlavorFusion.Models;

namespace FlavorFusion.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly FlavorFusionContext _context;

        public CreateModel(FlavorFusionContext context)
        {
            _context = context;
        }

        public SelectList MealPlanList { get; set; }

        [BindProperty]
        public Review Review { get; set; }

        public IActionResult OnGet()
        {
            MealPlanList = new SelectList(_context.MealPlan, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                MealPlanList = new SelectList(_context.MealPlan, "Id", "Name");
                return Page();
            }

            // Add the review to the context and save
            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
