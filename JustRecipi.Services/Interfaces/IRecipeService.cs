using System;
using System.Collections.Generic;
using JustRecipi.Data.Models;

namespace JustRecipi.Services.Interfaces
{
    public interface IRecipeService
    {
        public void AddRecipe(Recipe recipe);
        public void UpdateRecipe(Recipe recipe, Guid id);
        public void DeleteRecipe(Guid recipeId);
        public List<Recipe> GetAllRecipes();
        public Recipe GetRecipe(Guid recipeId);
    }
}