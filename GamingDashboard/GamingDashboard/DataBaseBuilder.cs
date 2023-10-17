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
        private static string connectionString = @"../../../DashBoardDB.db";
        public static void Initialize()
        {
            if(!File.Exists(connectionString))
            {
                SQLiteConnection.CreateFile(@"../../../DashBoardDB.db");
                //Building the database within this static class from now on, if you need changes to the DB do them here. 
                //To get a Fresh DB simply delete DashBoardDB.db from main folder and re-run the application. 

                //build the schema strings
                List<String> queries = new List<String>();
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Add USER table 
                    String CreateUserQuery = @"create table bla bla";
                    queries.Add(CreateUserQuery);
                    // Add SteamSpecial table 
                    String CreateSteamSpecialQuery = @"create table bla bla";
                    queries.Add(CreateSteamSpecialQuery);
                    // Add steamSpecialFavourites table 
                    String CreateSteamSpecialFavsQuery = @"create table bla bla";
                    queries.Add(CreateSteamSpecialFavsQuery);
                    // Add News table 
                    String CreateNewsQuery = @"create table bla bla";
                    queries.Add(CreateNewsQuery);
                    // add NewsFavourites table 
                    String CreateNewsFavQuery = @"create table bla bla";
                    queries.Add(CreateNewsFavQuery);



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
