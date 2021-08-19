using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustRecipi.Data.Models
{
    public class CookBookRecipe
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CookBookId { get; set; }
        public virtual CookBook CookBook { get; set; }
        
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}