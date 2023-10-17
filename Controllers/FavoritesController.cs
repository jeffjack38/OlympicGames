using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveCat = session.GetActiveCat(),
                ActiveGame = session.GetActiveGame(),
                Countries = session.GetMyCountries()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new CountrySession(HttpContext.Session);
            session.RemoveMyCountries();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveCat = session.GetActiveCat(),
                    ActiveGame = session.GetActiveGame()
                });
        }
    }
}
