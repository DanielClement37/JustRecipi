using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustRecipi.Data.Models;

namespace JustRecipi.Services.Interfaces
{
    public interface IRecipeService
    {
        public Task AddRecipe(Recipe recipe, string userId);
        public void UpdateRecipe(Recipe recipe, Guid id);
        public void DeleteRecipe(Guid recipeId);
        public Recipe GetRecipe(Guid recipeId);
    }
}