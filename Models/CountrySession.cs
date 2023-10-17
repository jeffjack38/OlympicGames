using Microsoft.AspNetCore.Http;

namespace OlympicGames.Models
{
    public class CountrySession
    {
        //set private constants for key names
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string CatKey = "cat";
        private const string GameKey = "game";

        //define constructor that accepts an argument of the ISession type then sotres the value in a private property named session
        private ISession session {  get; set; }
        public CountrySession(ISession session) {
            this.session = session;
        }

        //SetMyCountries() method to accept a list of Country objects
        public void SetMyCountries(List<Country> countries)
        {
            //use SetObject() extension method of the SessionExtension class to store the list of countries in session state
            session.SetObject(CountriesKey, countries);
            //store a count of countries in session state
            session.SetInt32(CountKey, countries.Count);
        }

        //get data store by SetMyCountries method, gets a list of the countries 
        public List<Country> GetMyCountries() => session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();

        //get count of teams
        public int GetMyCountryCount() => session.GetInt32(CountKey) ?? 0;

        //uses SetString() method of the ISEssion interface to store a string in session state
        public void SetActiveCat(string activeCat) => session.SetString(CatKey, activeCat);

        //uses GetSTring() to retrieve
        public string GetActiveCat() => session.GetString(CatKey);

        public void SetActiveGame(string activeGame) => session.SetString(GameKey, activeGame);
        public string GetActiveGame() => session.GetString(GameKey);

        //method to remove session country and count keys
        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }
    }
}
