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
        private const string RapidApiKey = "4e3ce5bc43mshb49cfacf0855d76p10cf24jsn1ddf30e8ccbd";
        private const string EpicRapidApiHost = "epic-store-games.p.rapidapi.com";

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
        ////   STEAMSPECIAL MANAGEMENT implimentation
        public void ReFreshSteamSpecialDatabase()
        {
        }




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

        public List<EpicSpecial> SearchEpicSales(string keyword)
        {
            return new List<EpicSpecial>(); 
        }

        public List<EpicSpecial> FilterEpicSalesByCategory(string category)
        {
            return new List<EpicSpecial>(); 
        }


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
