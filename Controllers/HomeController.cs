using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;
using System.Diagnostics;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(string activeCat = "all", string activeGame = "all")
        {
            var model = new CountryListViewModel {
                ActiveCat = activeCat,
                ActiveGame = activeGame,
                Categories = context.Categories.ToList(),
                Games = context.Games.ToList(),
            };

            IQueryable<Country> query = context.Countries;
            if (activeCat != "all")
                query = query.Where(t => 
                    t.Category.CategoryID.ToLower() == activeCat.ToLower());
            if (activeGame != "all")
                query = query.Where(t =>
                    t.Game.GameID.ToLower() == activeGame.ToLower());
            model.Countries = query.ToList();
            return View(model);

        }

    }
}