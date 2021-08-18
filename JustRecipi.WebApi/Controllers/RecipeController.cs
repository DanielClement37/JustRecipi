using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustRecipi.Data.Models;
using JustRecipi.Data.RequestModels;
using JustRecipi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JustRecipi.WebApi.Controllers
{
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;
        private readonly IAccountService _accountService;
        private readonly ICookBookService _cookBookService;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService, IAccountService accountService, ICookBookService cookBookService)
        {
            _logger = logger;
            _recipeService = recipeService;
            _accountService = accountService;
            _cookBookService = cookBookService;
        }
        
        [AllowAnonymous]
        [HttpGet("/api/recipe/{id}")]
        public ActionResult GetRecipe(Guid id)
        {
            var recipe = _recipeService.GetRecipe(id);
            return Ok(recipe);
        }

        [Authorize]
        [HttpPost("/api/recipes")]
        public async Task<ActionResult> AddRecipe([FromBody] NewRecipeRequest recipeRequest, [FromHeader] string authorization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model State is not valid");
            }
            
            var userId = await _accountService.UserIdFromJwtAsync(authorization.Substring(7));
            var cookBookId = _cookBookService.GetUserCookBookId(userId);

            var recipe = new Recipe
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthorId = userId,
                CookBookId = cookBookId,
                Title = recipeRequest.Title,
                Description = recipeRequest.Description,
                PrepTime = recipeRequest.PrepTime,
                CookTime = recipeRequest.CookTime,
                TotalTime = recipeRequest.PrepTime + recipeRequest.CookTime,
                Ingredients = recipeRequest.Ingredients,
                Instructions = recipeRequest.Instructions,
                NumServings = recipeRequest.NumServings
            };

            _recipeService.AddRecipe(recipe);

            return Ok($"{recipe.Title}: was added to the DB");
        }

        //TODO: Make Sure only the user who made or admin/mod the recipe can delete it
        [Authorize]
        [HttpDelete("/api/deleteRecipe/{id}")]
        public ActionResult DeleteRecipe(Guid id)
        {
            _recipeService.DeleteRecipe(id);
            return Ok($"Recipe deleted with ID: {id}");
        }

        //TODO: Make Sure only the user who made the recipe can update it
        [Authorize]
        [HttpPost("/api/editRecipe/{id}")]
        public ActionResult UpdateRecipe([FromBody] NewRecipeRequest recipeRequest, Guid recipeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model State is not valid");
            }

            var recipe = new Recipe
            {
                Title = recipeRequest.Title,
                Description = recipeRequest.Description,
                PrepTime = recipeRequest.PrepTime,
                CookTime = recipeRequest.CookTime,
                TotalTime = recipeRequest.PrepTime + recipeRequest.CookTime,
                Ingredients = recipeRequest.Ingredients,
                Instructions = recipeRequest.Instructions,
                NumServings = recipeRequest.NumServings
            };

            _recipeService.UpdateRecipe(recipe, recipeId);

            return Ok($"{recipe.Title}: was updated");
        }
    }
}