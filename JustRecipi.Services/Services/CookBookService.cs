using System;
using System.Collections.Generic;
using System.Linq;
using JustRecipi.Data;
using JustRecipi.Data.Models;
using JustRecipi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustRecipi.Services.Services
{
    public class CookBookService : ICookBookService
    {
        private readonly JustRecipiDbContext _db;

        public CookBookService(JustRecipiDbContext db)
        {
            _db = db;
        }
        //TODO: make Async
        public void CreateCookBook(CookBook cookBook)
        {
            _db.Add(cookBook);
            _db.SaveChanges();
        }

        public void AddRecipeToCookBook(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteCookBook(Guid cookBookId)
        {
            var cookBookToDelete = _db.Recipes.Find(cookBookId);
            if (cookBookToDelete != null)
            {
                _db.Remove(cookBookToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException(
                    "Can't delete a cookBook that doesn't exist"
                );
            }
        }

        public List<Recipe> GetCookBookRecipes(Guid cookBookId)
        {
            var recipes = from cookbookRecipe in _db.CookBookRecipes
                where cookbookRecipe.CookBookId == cookBookId
                join recipe in _db.Recipes
                    on cookbookRecipe.RecipeId equals recipe.Id
                select recipe;
            
           return recipes.ToList();
        }

        public Guid GetUserCookBookId(string userId)
        {
            return _db.CookBooks.Where(u => u.UserId == userId).FirstOrDefaultAsync().Result.Id;
        }
    }
}