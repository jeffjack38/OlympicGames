using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //create a CountrySession object
            var session = new CountrySession(HttpContext.Session);
            //call methods from the session state object to store the IDs of the active cat and agme in session state
            session.SetActiveCat(activeCat);
            session.SetActiveGame(activeGame);  

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

        public ViewResult Details(string id)
        {
           
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                Country = context.Countries .Include(t => t.Category).Include(t => t.Game).FirstOrDefault(t => t.CountryID == id),
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat()
            };
            return View(model);
        }

        // handles the POST request that's run when users click the "Add to Favorites" button on the Details page
        //this method will receive a CountryViewModel object as its parameter
        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries .Include(t => t.Category) .Include(t => t.Game) .Where(t => t.CountryID == model.Country.CountryID).FirstOrDefault();

            var session = new CountrySession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveCat = session.GetActiveCat(),
                    ActiveGame = session.GetActiveGame()
                }
                );
        }

    }
}