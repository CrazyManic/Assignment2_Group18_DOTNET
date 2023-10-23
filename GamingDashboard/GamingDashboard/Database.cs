using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Headers;
using System.Net.Http;

using Newtonsoft.Json;

namespace GamingDashboard
{
    //Required from "Manage NuGet Package" Sqlite, NewtonSoft.JSON

    // Quick explaination of the SQL database 
    // the steamFavourites and newsFavourite tables will be carbon copies of the API call, but with an attached userID. 

    // but for the sake of simplicity the Favourite Lists in C# and the Article/Sales Lists in C# will both utalize the same class. 
    // no need for a FavSteamSale class. etc. 

    // All interface methods should be implimented right here on DataBase and most of them should query the SQL lite database. 
    public class Database : IUserManager, IEpicSaleManager, INewsManager, IFavoritesManager
    {
        public User LogedInUser { get; set; } //after login in / logging out change this user value, will be tracked on all forms.
        public List<User> Users { get; set; }
        public List<News> NewsArticles { get; set; }
        public List<EpicSpecial> SteamSales { get; set; }
        public List<News> FavouriteNews { get; set; } // Use these dynamically such that the methods from the interface directly alter these lists. Or dont ¯\_(ツ)_/¯
        public List<EpicSpecial> FavouriteSales { get; set; }

        //EPIC api constant's
        private const string EpicApiBaseUrl = "https://epic-store-games.p.rapidapi.com/onSale";
        private const string EpicApiUpcomingUrl = "https://epic-store-games.p.rapidapi.com/comingSoon";
        private const string RapidApiKey = "4e3ce5bc43mshb49cfacf0855d76p10cf24jsn1ddf30e8ccbd";
        private const string EpicRapidApiHost = "epic-store-games.p.rapidapi.com";

        //IGN api constant's 
        private const string IGNApiBaseUrl = "https://ign-reviews.p.rapidapi.com/game-review/list";
        private const string IGNApiKey = "677cb7e77fmshe8a11fe1bc970e2p19ed36jsn9cfd3ce7a575";
        private const string IGNRapidApiHost = "ign-reviews.p.rapidapi.com";


        // The database class will be the only location where API calls and SQL queries will take palce. Feel free to create sub classes if you dont like everything all in one place. 

        //////////////////////////////////////////////////////////////////////////////////////
        ////   USER MANAGEMENT implimentation
        public List<User> GetUsers()
        {
            return new List<User>(); // Placeholder return
        }

        public User CreateUser(string username, string password, string email, string FirstName, string LastName)
        {
            return new User(); // Placeholder return
        }

        public User GetUserById(int userId)
        {
            return new User(); // Placeholder return
        }

        public User Login(string username, string password)
        {
            return new User(); // Placeholder return
        }

        public void Update(string username, string password, string email, string FirstName, string LastName)
        {

        }


        //////////////////////////////////////////////////////////////////////////////////////
        ////   EpicSPECIAL MANAGEMENT implimentation

        public async Task<List<EpicSpecial>> GetEpicSales()
        {
            //All required API inputs as declared by rapidAPI
            string locale = "us";
            string country = "us";
            string categories = "Games";
            string searchWords = "  ";

            using (var client = new HttpClient())
            {
                var requestUri = new Uri($"{EpicApiBaseUrl}?searchWords={searchWords}&locale={locale}&country={country}&categories={categories}"); //The API call string gets built

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,   //The request is declared
                    RequestUri = requestUri
                };

                request.Headers.Add("X-RapidAPI-Key", RapidApiKey);  //the request headers are attached, these are required by rapid API. 
                request.Headers.Add("X-RapidAPI-Host", EpicRapidApiHost);

                using (var response = await client.SendAsync(request))  //Generic C# http async request method.
                {
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    List<EpicSpecial> epicSpecials = JsonConvert.DeserializeObject<List<EpicSpecial>>(responseContent); //This JSON Conversion method requires your Model Class to exactly represent the response JSON from the api. 
                    return epicSpecials;  //returnm the api call
                }
            }

        }

        //Given a key search word and categories the search epic sales will contact the api with an updated URI requesting new filtered data.
        public async Task<List<EpicSpecial>> SearchEpicSales(string searchWords, string categories)
        {
            string locale = "us";
            string country = "us";
            if(searchWords.Length == 0)
            {
                searchWords = " "; //the api seems to reply with the top list of elements if a space is parsed as the search word. null entry will respond with 404. 
            }
            if(categories.Length == 0)
            {
                categories = "Games"; //default back to games.
            }

            using (var client = new HttpClient())
            {
                var requestUri = new Uri($"{EpicApiBaseUrl}?searchWords={searchWords}&locale={locale}&country={country}&categories={categories}"); //The API call string gets built

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,   //The request is declared
                    RequestUri = requestUri
                };

                request.Headers.Add("X-RapidAPI-Key", RapidApiKey);  //the request headers are attached, these are required by rapid API. 
                request.Headers.Add("X-RapidAPI-Host", EpicRapidApiHost);

                using (var response = await client.SendAsync(request))  //Generic C# http async request method.
                {
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    List<EpicSpecial> epicSpecials = JsonConvert.DeserializeObject<List<EpicSpecial>>(responseContent); //This JSON Conversion method requires your Model Class to exactly represent the response JSON from the api. 
                    return epicSpecials;  //returnm the api call
                }
            }
        }

        public async Task<List<EpicSpecial>> GetUpComingGames(string searchWords, string categories)
        {
            string locale = "us";
            string country = "us";

            if(searchWords == null)
            {
                searchWords = " "; //the api seems to reply with the top list of elements if a space is parsed as the search word. null entry will respond with 404. 
            }
            if ( categories == null)
            {
                categories = "Games"; //default back to games.
            }

            using (var client = new HttpClient())
            {
                var requestUri = new Uri($"{EpicApiUpcomingUrl}?searchWords={searchWords}&locale={locale}&country={country}&categories={categories}");

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,   //The request is declared
                    RequestUri = requestUri
                };
                request.Headers.Add("X-RapidAPI-Key", RapidApiKey);  //the request headers are attached, these are required by rapid API. 
                request.Headers.Add("X-RapidAPI-Host", EpicRapidApiHost);

                using( var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    List<EpicSpecial> epicUpcoming = JsonConvert.DeserializeObject<List<EpicSpecial>>(responseContent);
                    return epicUpcoming;
                }
            }

        }

        public List<EpicSpecial> FilterEpicSalesByCategory(string category)
        {
            return new List<EpicSpecial>(); 
        }


        //////////////////////////////////////////////////////////////////////////////////////
        ////   IGN MANAGEMENT implimentation

        


        //////////////////////////////////////////////////////////////////////////////////////
        ////   NEWS MANAGEMENT implimentation

        public void ReFreshNewsDatabase()
        {
        }

        public List<News> GetNewsArticles()
        {
            return new List<News>(); 
        }

        public List<News> SearchNews(string keyword)
        {
            return new List<News>(); // Placeholder return
        }

        public List<News> FilterNewsByCategory(string category)
        {
            return new List<News>(); 
        }

        ///////////////////////////////////////////////////////////////////////////////////
        ///         Favourites Management
        ///         
        public void AddNewsFavorite(int userId, int newsId)
        {
        }

        public void RemoveNewsFavorite(int userId, int newsId)
        {
        }

        public List<News> GetNewsFavorites(int userId)
        {
            return new List<News>(); 
        }

        public void AddSteamSaleFavorite(int userId, int saleId)
        {
        }

        public void RemoveSteamSaleFavorite(int userId, int saleId)
        {
        }

        public List<EpicSpecial> GetSteamSaleFavorites(int userId)
        {
            return new List<EpicSpecial>(); 
        }

    }

    //Literally all database methods can go here, just make sure they are all grouped in order according to the order of the lists. 
}
