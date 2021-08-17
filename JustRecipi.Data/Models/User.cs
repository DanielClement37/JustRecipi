using System;
using Microsoft.AspNetCore.Identity;

namespace JustRecipi.Data.Models
{
    public class User : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}