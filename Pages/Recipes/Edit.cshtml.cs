using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FlavorFusion.Pages.Recipes
{
    public class EditModel : RecipeCategoriesPageModel
    {
        private readonly FlavorFusionContext _context;

        public EditModel(FlavorFusionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipe
                .Include(r => r.User)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "UserName");
            PopulateAssignedCategoryData(_context, Recipe);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeToUpdate = await _context.Recipe

                .Include(r => r.User)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Recipe>(
                recipeToUpdate,
                "Recipe",
                r => r.Name, r=> r.User, r => r.Ingredients, r => r.Instructions))
            {
                UpdateBookCategories(_context, selectedCategories, recipeToUpdate);

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, recipeToUpdate);

            return Page();
        }
    }
}
