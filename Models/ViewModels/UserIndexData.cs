using FlavorFusion.Models;

namespace FlavorFusion.ViewModels
{
    public class UserIndexData
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public IEnumerable<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
