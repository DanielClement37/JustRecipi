using System;
using System.Collections.Generic;
using JustRecipi.Data.Models;

namespace JustRecipi.Services.Interfaces
{
    public interface IReviewService
    {
        public void AddReview(Review review);
        public void DeleteReview(Guid reviewId);
        public List<Review> GetRecipeReviews(Guid recipeId);
    }
}