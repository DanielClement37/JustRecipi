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
            return _db.Recipes.Where(r => r.CookBookId == cookBookId).ToList();
        }

        public Guid GetUserCookBookId(string userId)
        {
            return _db.CookBooks.Where(u => u.UserId == userId).FirstOrDefaultAsync().Result.Id;
        }
    }
}