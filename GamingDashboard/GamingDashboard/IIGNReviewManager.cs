using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public interface IIGNReviewManager
    {
        Task<List<EpicSpecial>> GetIGNReview(); // Should return all IGN Review in the sql database
        Task<List<EpicSpecial>> SearchIGNReview(string platform, string sortBy); // should return a filtered list of IGN Reviews according to the string platform and string sortBy, from the api.
        List<IGNReview> FilterIGNREVIEWByMinScore(int minScore); // should return a list of IGN objects by minScore, use where IGN.minScore LIKE minScore.
        List<IGNReview> FilterIGNREVIEWByMaxScore(int maxScore); // should return a list of IGN objects by maxScore, use where IGN.manScore LIKE maxScore.
        List<IGNReview> FilterIGNREVIEWByPublishedDateAfter(string publishedAfter); // should return a list of IGN objects by publishedAfter, use where IGN.publishedAfter LIKE publishedAfter.
        List<IGNReview> FilterIGNREVIEWByPublishedDateBefore(string publishedBefore); // should return a list of IGN objects by publishedBefore, use where IGN.publishedAfter LIKE publishedBefore.
    }
}
