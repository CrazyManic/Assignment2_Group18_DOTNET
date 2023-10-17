using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface ISteamSaleManager
    {
        void ReFreshSteamSpecialDatabase();  // refresh the API daily, and rewrite the database. 
        List<SteamSpecial> GetSteamSales(); // Should return all steam sales in the sql database
        List<SteamSpecial> SearchSteamSales(string keyword); // should return a filtered list of steam objects according to the search string, use wildcards in SQL 
        List<SteamSpecial> FilterSteamSalesByCategory(string category); // should return a list of steam sale objects by category, use where steam.catagory LIKE category.

    }
}
