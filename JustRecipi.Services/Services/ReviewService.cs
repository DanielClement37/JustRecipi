using System;
using System.Collections.Generic;
using System.Linq;
using JustRecipi.Data;
using JustRecipi.Data.Models;
using JustRecipi.Services.Interfaces;

namespace JustRecipi.Services.Services
{
    public class ReviewService : IReviewService
    {
        private readonly JustRecipiDbContext _db;

        public ReviewService(JustRecipiDbContext db)
        {
            _db = db;
        }
        //TODO: make Async
        public void AddReview(Review review)
        {
            _db.Add(review);
            _db.SaveChanges();
        }

        public void DeleteReview(Guid reviewId)
        {
            var reviewToDelete = _db.Reviews.Find(reviewId);
            if (reviewToDelete != null)
            {
                _db.Remove(reviewToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException(
                    "Can't delete a review that doesn't exist"
                );
            }
        }

        public List<Review> GetRecipeReviews(Guid recipeId)
        {
            return _db.Reviews.Where(r => r.RecipeId == recipeId).ToList();
        }
    }
}