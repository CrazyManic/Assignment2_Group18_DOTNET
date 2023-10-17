using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface IFavoritesManager
    {
        void AddNewsFavorite(int userId, int newsId);

        void RemoveNewsFavorite(int userId, int newsId);

        List<News> GetNewsFavorites(int userId); // given a user id the method will return all his favourites as news classes
        void AddSteamSaleFavorite(int userId, int saleId); //Given the current userId and SteamSale Id a new favourite should be added to the db

        void RemoveSteamSaleFavorite(int userId, int saleId); //Given the current userId and SteamSale Id a favourite should be removed from the db
        List<SteamSpecial> GetSteamSaleFavorites(int userId); // Given a user id the method will return all SteamSale favourites in the db
    }
}
