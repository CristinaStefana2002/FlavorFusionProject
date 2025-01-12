﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlavorFusion.Data;
using FlavorFusion.Models;

namespace FlavorFusion.Pages.MealPlans
{
    public class CreateModel : PageModel
    {
        private readonly FlavorFusion.Data.FlavorFusionContext _context;

        public CreateModel(FlavorFusion.Data.FlavorFusionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MealPlan MealPlan { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MealPlan.Add(MealPlan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
