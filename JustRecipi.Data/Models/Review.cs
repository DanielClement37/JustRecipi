using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustRecipi.Data.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        public string AuthorId { get; set; }
        public Guid RecipeId { get; set; }
        public int NumStars { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [ForeignKey("AuthorId")]
        public virtual User User { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
        
        
    }
}