using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace GamingDashboard
{
    public static class DataBaseBuilder
    {
        private static string connectionString = "Data Source=../../../DashBoardDB.db;";
        public static void Initialize()
        {
            if(!File.Exists(@"../../../DashBoardDB.db"))
            {
                SQLiteConnection.CreateFile(@"../../../DashBoardDB.db");
                //Building the database within this static class from now on, if you need changes to the DB do them here. 
                //To get a Fresh DB simply delete DashBoardDB.db from main folder and re-run the application. 


                //My steam WEBAPI 788274B97C3AD71DB57A4950A246CAEE  for STEAMAPI

                //build the schema strings
                List<String> queries = new List<String>();
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Create USER table
                    queries.Add(@"CREATE TABLE Users (
                                    UserId INTEGER PRIMARY KEY ,
                                    Username TEXT NOT NULL UNIQUE,
                                    Password TEXT,
                                    Email TEXT,
                                    FirstName TEXT,
                                    LastName TEXT
                                )");

                    // Create SteamSpecial table
                    queries.Add(@"CREATE TABLE SteamSpecials (
                                    SaleId INTEGER PRIMARY KEY,
                                    GameTitle TEXT,
                                    DiscountPercentage REAL,
                                    Category TEXT
                                )");

                    // Create SteamSpecialFavourites table
                    queries.Add(@"CREATE TABLE SteamSpecialFavourites (
                                    UserId INTEGER,
                                    SaleId INTEGER,
                                    PRIMARY KEY (UserId, SaleId),
                                    FOREIGN KEY (UserId) REFERENCES Users (UserId),
                                    FOREIGN KEY (SaleId) REFERENCES SteamSpecials (SaleId)
                                )");

                    // Create News table
                    queries.Add(@"CREATE TABLE News (
                                    NewsId INTEGER PRIMARY KEY,
                                    Title TEXT,
                                    Content TEXT,
                                    Category TEXT,
                                    PublicationDate DATETIME
                                )");

                    // Create NewsFavourites table
                    queries.Add(@"CREATE TABLE NewsFavourites (
                                    UserId INTEGER,
                                    NewsId INTEGER,
                                    PRIMARY KEY (UserId, NewsId),
                                    FOREIGN KEY (UserId) REFERENCES Users (UserId),
                                    FOREIGN KEY (NewsId) REFERENCES News (NewsId)
                                )");



                    // execute the queries 
                    using (var command = new SQLiteCommand(connection))
                    {
                        foreach(String querie in queries)
                        {
                            command.CommandText = querie;
                            command.ExecuteNonQuery();
                        }
                        
                    }
                }
            }


        }
    }
}
