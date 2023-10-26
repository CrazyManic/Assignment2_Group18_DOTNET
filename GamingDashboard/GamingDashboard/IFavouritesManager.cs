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
        void AddEpicFavorite(User user, EpicSpecial epic); //Given the current userId and SteamSale Id a new favourite should be added to the db

        void RemoveEpicFavorite(User user, EpicSpecial epic); //Given the current userId and SteamSale Id a favourite should be removed from the db

        bool isEpicAlreadyAdded(User user, EpicSpecial epic);
        List<EpicFavourite> GetFavorites(User user); // Given a user id the method will return all SteamSale favourites in the db
    }
}
