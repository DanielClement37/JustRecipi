using System;
using System.Threading.Tasks;
using JustRecipi.Data.RequestModels;
using JustRecipi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JustRecipi.WebApi.Controllers
{
    public class CookBookController : Controller
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly ICookBookService _cookBookService;
        private readonly IAccountService _accountService;

        public CookBookController(ILogger<RecipeController> logger, ICookBookService cookBookService, IAccountService accountService)
        {
            _logger = logger;
            _cookBookService = cookBookService;
            _accountService = accountService;
        }

        [HttpGet("api/cookbook/{id}")]
        public ActionResult GetCookBookRecipes(Guid id)
        {
            var recipes = _cookBookService.GetCookBookRecipes(id);
            return Ok(recipes);
        }
    }
}