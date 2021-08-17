﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustRecipi.Data.Models;
using JustRecipi.WebApi.RequestModels;
using JustRecipi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JustRecipe.Web.Controllers
{
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [HttpGet("/api/recipes")]
        public ActionResult GetRecipes()
        {
            var recipes = _recipeService.GetAllRecipes(); // add pagination
            return Ok(recipes);
        }

        [HttpGet("/api/recipe/{id}")]
        public ActionResult GetRecipe(Guid id)
        {
            var recipe = _recipeService.GetRecipe(id);
            return Ok(recipe);
        }

        [HttpPost("/api/recipes")]
        public ActionResult AddRecipe([FromBody] NewRecipeRequest recipeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model State is not valid");
            }

            var now = DateTime.UtcNow;

            var recipe = new Recipe
            {
                CreatedAt = now,
                UpdatedAt = now,
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

        [HttpDelete("/api/deleteRecipe/{id}")]
        public ActionResult DeleteRecipe(Guid id)
        {
            _recipeService.DeleteRecipe(id);
            return Ok($"Recipe deleted with ID: {id}");
        }

        [HttpPost("/api/editRecipe/{id}")]
        public ActionResult UpdateRecipe([FromBody] NewRecipeRequest recipeRequest, Guid id)
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

            _recipeService.UpdateRecipe(recipe, id);

            return Ok($"{recipe.Title}: was updated");
        }
    }
}