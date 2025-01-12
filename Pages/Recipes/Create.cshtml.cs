using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlavorFusion.Pages.Recipes
{
    public class CreateModel : RecipeCategoriesPageModel
    {
        private readonly FlavorFusionContext _context;

        public CreateModel(FlavorFusionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public IActionResult OnGet()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "UserName");
            PopulateAssignedCategoryData(_context, new Recipe());
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRecipe = new Recipe();

            if (selectedCategories != null)
            {
                newRecipe.RecipeCategories = new List<RecipeCategory>();
                foreach (var cat in selectedCategories)
                {
                    var categoryToAdd = new RecipeCategory
                    {
                        CategoryId = int.Parse(cat)
                    };
                    newRecipe.RecipeCategories.Add(categoryToAdd);
                }
            }

            if (await TryUpdateModelAsync<Recipe>(
                newRecipe,
                "Recipe",
                r => r.Name, r => r.Ingredients, r => r.Instructions))
            {
                _context.Recipe.Add(newRecipe);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newRecipe);
            return Page();
        }
    }
}
