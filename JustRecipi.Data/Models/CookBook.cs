using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustRecipi.Data.Models
{
    public class CookBook
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Recipe> Recipes { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}