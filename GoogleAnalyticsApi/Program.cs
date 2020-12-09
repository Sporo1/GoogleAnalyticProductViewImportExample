using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.AnalyticsReporting.v4.Data;
using Newtonsoft.Json;
namespace GoogleAnalyticsApi
{
    class Program
    {
        static  void Main(string[] args)
        {
            var lines = File.ReadAllText("client_secret.json");
            var service = new GoogleAnalyticsReportingService();
            var credentials = JsonConvert.DeserializeObject<Credential>(lines);

            var dateRange = new Google.Apis.AnalyticsReporting.v4.Data.DateRange()
            {
                StartDate = "30daysAgo",
                EndDate = "yesterday"
            };
            var Dimensions = new List<Dimension>()
            {
                new Dimension(){Name="ga:pageTitle"},
                new Dimension(){Name="ga:pagePath"},
                new Dimension(){Name="ga:date"}
            };
            var Metrics = new List<Metric>()
            {
                new Metric(){Expression="ga:uniquePageviews" ,Alias="PageViews"}
            };
            if (credentials != null)
            {
                Task.Run(async () =>
                {
                    var pageViews = await service.GetPageBehaviors("207485285", dateRange, Dimensions, Metrics, null, credentials);
                    Console.WriteLine("Page/t/t/t/t/t/t/t/t/t/t/t/t/t/t Url/t/t/t/t/t/t/t/t/t/t/t/t/t/t Views");
                    if (pageViews != null && pageViews.Count > 0)
                    {
                        pageViews.ForEach((row) =>
                        {
                            Console.WriteLine($"{row.PageTitle}/t/t/t/t/t/t/t/t/t/t/t/t/t/t {row.PagePath}/t/t/t/t/t/t/t/t/t/t/t/t/t/t {row.UniquePageViews}");
                        });
                    }
                }).Wait();
            }
            Console.ReadKey();
        }
    }
}
