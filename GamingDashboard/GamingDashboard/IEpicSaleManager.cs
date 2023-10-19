using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface IEpicSaleManager
    {
        Task<List<EpicSpecial>> GetEpicSales(); // Should return all steam sales in the sql database
        Task<List<EpicSpecial>> SearchEpicSales(string keyword, string category); // should return a filtered list of steam objects according to the search string, from the api.
        List<EpicSpecial> FilterEpicSalesByCategory(string category); // should return a list of steam sale objects by category, use where steam.catagory LIKE category.

        Task<List<EpicSpecial>> GetUpComingGames(string keyword, string category); // will return a listof new and upcoming games, if no inputs are given the method will return the most anticipated. 

    }
}
