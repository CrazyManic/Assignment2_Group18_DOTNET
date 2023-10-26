using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Headers;
using System.Net.Http;

using Newtonsoft.Json;
using System.Data.SQLite;

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
        // data source
        private static string connectionString = "Data Source=../../../DashBoardDB.db;";

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

        // The database class will be the only location where API calls and SQL queries will take palce. Feel free to create sub classes if you dont like everything all in one place. 

        //////////////////////////////////////////////////////////////////////////////////////
        ////   USER MANAGEMENT implimentation
        public List<User> GetUsers()
        {
            return new List<User>(); // Placeholder return
        }

        public User CreateUser(string username, string password, string email, string FirstName, string LastName)
        {
            User user = new User();
            using(var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string checkUserName = "SELECT * FROM Users where Username = @username";

                using (SQLiteCommand command = new SQLiteCommand(checkUserName, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                     using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return null;
                        }

                    }  
                }

                // if there is no username present procced
                string insertUser = "INSERT INTO Users(username, password,email, firstName, lastName) VALUES (@username, @password, @email, @firstName, @lastName) ";

                using(SQLiteCommand command = new SQLiteCommand(insertUser, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@firstName", FirstName);
                    command.Parameters.AddWithValue("@lastName", LastName);


                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // User creation successful; return true.
                        user = GetUserByUsername(username);
                        
                    }
                }
            }
            return user;
            
        }

        public User GetUserById(int userId)
        {
            return null; // Placeholder return
        }
        public User GetUserByUsername(string username)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "select * from users where username = @username";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                   

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            // return a user object instead of true or false
                            User user = new User
                            {
                                //UserId = int.Parse(reader["UserId"].ToString()), // Assuming UserId is an int

                                UserFirstName = reader["FirstName"].ToString(),
                                UserLastName = reader["LastName"].ToString(),
                                UserEmail = reader["Email"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["password"].ToString()
                            };
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        public User Login(string username, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "select * from users where username = @username AND Password = @password";
                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            // return a user object instead of true or false
                            User user = new User
                            {
                               UserId = int.Parse(reader["UserId"].ToString()), // Assuming UserId is an int
                                
                                UserFirstName = reader["FirstName"].ToString(),
                                UserLastName = reader["LastName"].ToString(),
                                UserEmail = reader["Email"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["password"].ToString()
                            };
                            return user;
                        }
                    }
                }
            }
            return null;

        }

        public string Update(int userId, string username, string password, string email, string FirstName, string LastName)
        {
            
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string checkUserName = "SELECT * FROM Users WHERE Username = @username AND userId != @userId";

                using (SQLiteCommand checkCommand = new SQLiteCommand(checkUserName, connection))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);
                    checkCommand.Parameters.AddWithValue("@userId", userId);

                    using (SQLiteDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            return "Sorry! Username is already in use by another user!"; // Username is already in use by another user.
                        }
                    }
                }

                string updateUser = "UPDATE Users SET Username = @username, Password = @password, Email = @email, FirstName = @firstName, LastName = @lastName WHERE userId = @userId";

                using (SQLiteCommand updateCommand = new SQLiteCommand(updateUser, connection))
                {
                    updateCommand.Parameters.AddWithValue("@username", username);
                    updateCommand.Parameters.AddWithValue("@password", password);
                    updateCommand.Parameters.AddWithValue("@email", email);
                    updateCommand.Parameters.AddWithValue("@firstName", FirstName);
                    updateCommand.Parameters.AddWithValue("@lastName", LastName);
                    updateCommand.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                       return "User information updated successfully" ; // User information updated successfully.
                    }
                    else
                    {
                        return "Couldn't update user details!";

                    }
                }
            }

          
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

        public void AddEpicFavorite(User user, EpicSpecial epic)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the EpicSpecial is already in the user's favorites
                using (SQLiteCommand checkCommand = new SQLiteCommand("SELECT COUNT(*) FROM EpicFavourites WHERE UserId = @UserId AND EpicId = @EpicId", connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    checkCommand.Parameters.AddWithValue("@EpicId", epic.Id);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count == 0)
                    {
                        // If the EpicSpecial is not in the user's favorites, add it
                        using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO EpicFavourites (UserId, EpicId, Title, Price, imageURL) VALUES (@UserId, @EpicId, @Title, @Price, @imageURL)", connection))
                        {
                            insertCommand.Parameters.AddWithValue("@UserId", user.UserId);
                            insertCommand.Parameters.AddWithValue("@EpicId", epic.Id);
                            insertCommand.Parameters.AddWithValue("@Title", epic.Title);
                            insertCommand.Parameters.AddWithValue("@Price", (int)epic.CurrentPrice);
                            insertCommand.Parameters.AddWithValue("@imageURL", epic.KeyImages.FirstOrDefault()?.Url);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }

        }

        public bool isEpicAlreadyAdded(User user, EpicSpecial epic)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the EpicSpecial is already in the user's favorites
                using (SQLiteCommand checkCommand = new SQLiteCommand("SELECT COUNT(*) FROM EpicFavourites WHERE UserId = @UserId AND EpicId = @EpicId", connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    checkCommand.Parameters.AddWithValue("@EpicId", epic.Id);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count == 0)
                    {
                        connection.Close();
                        return false;
                    }
                    else
                    {
                        connection.Close();
                        return true;
                    }
                }
            }

        }

        public void RemoveEpicFavorite(User user, EpicSpecial epic)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the EpicSpecial is in the user's favorites
                using (SQLiteCommand checkCommand = new SQLiteCommand("SELECT COUNT(*) FROM EpicFavourites WHERE UserId = @UserId AND EpicId = @EpicId", connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    checkCommand.Parameters.AddWithValue("@EpicId", epic.Id);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        // If the EpicSpecial is in the user's favorites, delete it
                        using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM EpicFavourites WHERE UserId = @UserId AND EpicId = @EpicId", connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@UserId", user.UserId);
                            deleteCommand.Parameters.AddWithValue("@EpicId", epic.Id);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }
        }

        public List<EpicSpecial> GetFavorites(int userId)
        {
            return new List<EpicSpecial>(); 
        }

    }

    //Literally all database methods can go here, just make sure they are all grouped in order according to the order of the lists. 
}
