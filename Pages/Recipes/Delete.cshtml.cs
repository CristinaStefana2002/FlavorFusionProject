﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Authorization;

namespace FlavorFusion.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly FlavorFusion.Data.FlavorFusionContext _context;

        public DeleteModel(FlavorFusion.Data.FlavorFusionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FirstOrDefaultAsync(m => m.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }
            else
            {
                Recipe = recipe;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                Recipe = recipe;
                _context.Recipe.Remove(Recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
