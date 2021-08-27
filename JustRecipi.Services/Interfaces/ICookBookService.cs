using System;
using System.Collections.Generic;
using JustRecipi.Data.Models;

namespace JustRecipi.Services.Interfaces
{
    public interface ICookBookService
    {
        public void CreateCookBook(CookBook cookBook);
        public void AddRecipeToCookBook(Recipe recipe);
        public void DeleteCookBook(Guid cookBookId);
        public List<Recipe> GetCookBookRecipes(Guid cookBookId);
        public Guid GetUserCookBookId(string userId);
    }
}