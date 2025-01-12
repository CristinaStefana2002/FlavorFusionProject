using FlavorFusion.Data;
using FlavorFusion.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FlavorFusion.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly FlavorFusionContext _context;

        public IndexModel(FlavorFusionContext context)
        {
            _context = context;
        }

        public RecipeData RecipeD { get; set; }
        public int RecipeID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            RecipeD = new RecipeData();

            RecipeD.Recipes = await _context.Recipe
                .Include(r => r.User)
                .Include(r => r.RecipeCategories)
                .ThenInclude(rc => rc.Category)
                .AsNoTracking()
                .OrderBy(r => r.Name)
                .ToListAsync();

            if (id != null)
            {
                RecipeID = id.Value;
                Recipe recipe = RecipeD.Recipes
                    .Where(r => r.Id == id.Value).SingleOrDefault();

                RecipeD.Categories = recipe?.RecipeCategories.Select(rc => rc.Category);
            }

            if (categoryID != null)
            {
                CategoryID = categoryID.Value;
                RecipeD.Recipes = RecipeD.Recipes
                    .Where(r => r.RecipeCategories.Any(rc => rc.CategoryId == CategoryID))
                    .ToList();
            }
        }
    }
}
