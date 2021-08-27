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
        private readonly ICookBookService _cookBookService;
        private readonly IAccountService _accountService;

        public CookBookController( ICookBookService cookBookService, IAccountService accountService)
        {
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