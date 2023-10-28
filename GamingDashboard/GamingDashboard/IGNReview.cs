using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public class IGNReview
    {
        public string Id { get; set; }
        public List<PublishDate> publishDate { get; set; }
        public string Article {  get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public List<Platform> Platforms { get; set; }
        public double minScore { get; set; }

        public string Score { get; set; }
        public double maxScore { get; set; } 
    
    }

    public class Platform
    {
        public string PlatformName { get; set; }
    }

    public class PublishDate
    { 
        public string Publish { get; set;} 

        public string Description { get; set;}
    
    }

}
