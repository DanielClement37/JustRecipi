using System;
using System.Collections.Generic;
using System.Linq;
using JustRecipi.Data;
using JustRecipi.Data.Models;
using JustRecipi.Services.Interfaces;


namespace JustRecipi.Services.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly JustRecipiDbContext _db;

        public RecipeService(JustRecipiDbContext db)
        {
            _db = db;
        }
        //TODO: make Async
        public void AddRecipe(Recipe recipe)
        {
            _db.Add(recipe);
            _db.SaveChanges();
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