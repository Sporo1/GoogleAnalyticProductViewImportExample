using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsApi
{/// <summary>
    //Page Value ga:pageValue
    //Entrancesga:entrances
    //Entrances / Pageviews ga:entranceRate
    //Pageviews ga:pageviews
    //Pages / Session ga:pageviewsPerSession
    //Unique Pageviews ga:uniquePageviews
    //Time on Pagega:timeOnPage
    //Avg.Time on Pagega:avgTimeOnPage
    //Exitsga:exits
    //% Exit ga:exitRate
    /// </summary>
    public class SiteContentAllPages
    {
        public string PageTitle { get; set; }
        public string PagePath { get; set; }
        public long? PageViews { get; set; }
        public long? UniquePageViews { get; set; }
        public TimeSpan AvarageTimeOnPage { get; set; }
        public long Entrances { get; set; }
        public decimal BounceRate { get; set; }
        public decimal ExitRate { get; set; }
        public decimal PageValue { get; set; }
        public DateTime Date { get; set; }
    }
}
