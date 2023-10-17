using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{

    // Quick explaination of the SQL database 
    // the steamFavourites and newsFavourite tables will be carbon copies of their non favourite counter part. 
    // in doing so a user can save a favourite forever in the database even if that steam sale item dissapears from the API at some point. 

    // but for the sake of simplicity the Favourite Lists in C# and the Article/Sales Lists in C# will both utalize the same class. 
    // no need for a FavSteamSale class. etc. 

    // All interface methods should be implimented right here on DataBase and most of them should query the SQL lite database. 
    public class Database : IUserManager, ISteamSaleManager, INewsManager, IFavoritesManager
    {
        public User LogedInUser { get; set; } //after login in / logging out change this user value, will be tracked on all forms.
        public List<User> Users { get; set; }
        public List<News> NewsArticles { get; set; }
        public List<EpicSpecial> SteamSales { get; set; }
        public List<News> FavouriteNews { get; set; } // Use these dynamically such that the methods from the interface directly alter these lists. Or dont ¯\_(ツ)_/¯
        public List<EpicSpecial> FavouriteSales { get; set; }

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

        public List<EpicSpecial> GetSteamSales()
        {
            return new List<EpicSpecial>(); 
        }

        public List<EpicSpecial> SearchSteamSales(string keyword)
        {
            return new List<EpicSpecial>(); 
        }

        public List<EpicSpecial> FilterSteamSalesByCategory(string category)
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
