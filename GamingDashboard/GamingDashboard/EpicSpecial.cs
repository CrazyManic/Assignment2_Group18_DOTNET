using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDashboard
{
    public class EpicSpecial
    {
        // GET app news
        public string Title { get; set; }
        public string Id { get; set; }
        public string Namespace { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool IsCodeRedemptionOnly { get; set; }
        public List<KeyImages> KeyImages { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Url { get; set; }
        public List<Category> Categories { get; set; }
        public Price Price { get; set; }
        public DateTime? PrePurchase { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime PcReleaseDate { get; set; }
        public DateTime? ViewableDate { get; set; }
        public ApproximateReleasePlan ApproximateReleasePlan { get; set; }
        public string PublisherName { get; set; }

        // API example 
        //title:"FROGUE"
        //id:"82c323ee570a4c928a151493804d8e8a"
        //namespace:"fbb8cd7f211345bab8e723a90b0fd8cf"
        //description:"Embark in a journey to rescue your dog in FROGUE, a Roguelike Bullet Hell Platformer."
        //effectiveDate:"2099-01-01T00:00:00.000Z"
        //isCodeRedemptionOnly:false
        //keyImages:
        //currentPrice:699
        //url:"https://store.epicgames.com/en-US/p/frogue-c91fc5"
        //categories:
        //price:
        //prePurchase:null
        //releaseDate:"2022-12-31T00:00:00.000Z"
        //pcReleaseDate:"2022-12-31T00:00:00.000Z"
        //viewableDate:"2022-06-13T04:00:00.000Z"
        //approximateReleasePlan:
        //publisherName:"Wired Dreams Studio"
    }

    public class KeyImages
    {

        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Price
    {
        public decimal PriceValue { get; set; }
    }

    public class Category
    {
        public string Path { get; set; }
    }

    public class ApproximateReleasePlan
    {
        public int? Day { get; set; }
        public int? Month { get; set; }
        public string Quarter { get; set; }
        public int? Year { get; set; }
        public string ReleaseDateType { get; set; }
    }

    // im going to have to write a method to fetch the URL from steam API, by cutting the link from the steamSpecial API down to the numerical code and passing it as an argument for steamAPI to grab the image url.
}
