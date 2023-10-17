using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface INewsManager
    {
        void ReFreshNewsDatabase();//e refresh news database class should check the date in SQL datatable, if todays system.date != the sql date.
                                    // the contents of the IGN databse should be dropped and the IGN news API should be called again and the database will be rewriten.
                                    // finally the old date in the database will be replaced with the new date. 
        List<News> GetNewsArticles(); // Should get all news articles in the database
        List<News> SearchNews(string keyword); // Given a search string a new list of filtered news should be returned. Use LIKE for sql
        List<News> FilterNewsByCategory(string category); // given a category string the filtermethod should return a new List of News from the database that matches the query. Use wildcard operators % LIKE %
    }
}
