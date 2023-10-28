using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public class IGNFavourite
    {

        public int UserId { get; set; }
        public string IGNId { get; set; }
        public string Name { get; set; }
        public double Score{ get; set; }

        public string imageUrl { get; set; }


    }
}
