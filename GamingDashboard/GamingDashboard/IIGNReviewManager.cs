using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface IIGNReviewManager
    {
        Task<List<IGNReview>> GetIGNReview(); // Should return all IGN Review in the sql database
        Task<List<IGNReview>> SearchIGNReview(string qurry); // should return a filtered list of IGN Reviews according to the string quary, from the api.
        Task<List<IGNReview>> PlatformIGNReview(string platform);

    }
}
