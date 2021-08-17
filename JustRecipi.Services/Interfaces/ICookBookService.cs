using System;
using System.Collections.Generic;
using JustRecipi.Data.Models;

namespace JustRecipi.Services.Interfaces
{
    public interface ICookBookService
    {
        public void CreateCookBook(CookBook cookBook);
        public void DeleteCookBook(Guid cookBookId);
        public List<Recipe> GetCookBookRecipes(Guid cookBookId);
    }
}