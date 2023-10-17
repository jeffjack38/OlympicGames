using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        //calls Index() action method when user clicks on the "My Favorite Countries" link
        [HttpGet]
        public IActionResult Index()
        {
            // create new  CountrySession object and posst to the Session property of the HttpContext property
            var session = new CountrySession(HttpContext.Session);
            // create new CountryListViewModel object to load it with data from tsession state 
            var model = new CountryListViewModel
            {
                ActiveCat = session.GetActiveCat(),
                ActiveGame = session.GetActiveGame(),
                Countries = session.GetMyCountries()
            };
            return View(model);
        }

        //called when user clicks "Clear Favorites" from Favorites page
        [HttpPost]
        public RedirectToActionResult Delete()
        {
            //create new CountrySession object and passing it the Session property of the controller's HttpContext property
            var session = new CountrySession(HttpContext.Session);
            //call RemoveMyCountries() method of the CountrySession object
            session.RemoveMyCountries();

            //store message in TempData to tell user the favorite country cleared, the layout displays this message
            TempData["message"] = "Favorite countries cleared";

            //redirect back to Home page, get Id values of active cat and game that are stored in session state and build the route parameters of the URL
            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveCat = session.GetActiveCat(),
                    ActiveGame = session.GetActiveGame()
                });
        }
    }
}
