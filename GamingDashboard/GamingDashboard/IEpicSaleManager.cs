using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface IEpicSaleManager
    {
        void ReFreshSteamSpecialDatabase();  // refresh the API daily, and rewrite the database. 
        List<EpicSpecial> GetEpicSales(); // Should return all steam sales in the sql database
        List<EpicSpecial> SearchEpicSales(string keyword); // should return a filtered list of steam objects according to the search string, use wildcards in SQL 
        List<EpicSpecial> FilterEpicSalesByCategory(string category); // should return a list of steam sale objects by category, use where steam.catagory LIKE category.

    }
}
