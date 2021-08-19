using System;
using System.Linq;
using System.Threading.Tasks;
using JustRecipi.Data;
using JustRecipi.Data.Models;
using JustRecipi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace JustRecipi.Services.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly JustRecipiDbContext _db;

        public RecipeService(JustRecipiDbContext db)
        {
            _db = db;
        }
       
        public async Task AddRecipe(Recipe recipe, string userId)
        {
            await _db.AddAsync(recipe);

            var authorCookBook = await _db.CookBooks.Where(u => u.UserId == userId).FirstOrDefaultAsync();
            var newCookBookRecipe = new CookBookRecipe()
            {
                CookBookId = authorCookBook.Id,
                RecipeId = recipe.Id
            };
            await _db.CookBookRecipes.AddAsync(newCookBookRecipe);
            
            await _db.SaveChangesAsync();
        }

        public void DeleteRecipe(Guid recipeId)
        {
            var recipeToDelete = _db.Recipes.Find(recipeId);
            if (recipeToDelete != null)
            {
                _db.Remove(recipeToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException(
                "Can't delete a recipe that doesn't exist"
                );
            }
        }


        public Recipe GetRecipe(Guid recipeId)
        {
            return _db.Recipes.Find(recipeId);
        }
        public void UpdateRecipe(Recipe newRecipe, Guid recipeId)
        {
            var currentRecipe = _db.Recipes.Find(recipeId);
            if(currentRecipe != null)
            {
                currentRecipe.Title = newRecipe.Title;
                currentRecipe.Description = newRecipe.Description;
                currentRecipe.PrepTime = newRecipe.PrepTime;
                currentRecipe.CookTime = newRecipe.CookTime;
                currentRecipe.TotalTime = newRecipe.TotalTime;
                currentRecipe.NumServings = newRecipe.NumServings;
                currentRecipe.Ingredients = newRecipe.Ingredients;
                currentRecipe.Instructions = newRecipe.Instructions;
                currentRecipe.UpdatedAt = DateTime.UtcNow;

                _db.Update(currentRecipe);
            }

            _db.SaveChanges();
        }
    }
}