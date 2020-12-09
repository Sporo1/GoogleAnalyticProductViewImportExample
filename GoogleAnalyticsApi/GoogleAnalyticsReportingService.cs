using Google.Apis.AnalyticsReporting.v4.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsApi
{
    public class GoogleAnalyticsReportingService : IGoogleAnalyticsReportingService
    {
        public async Task<List<SiteContentAllPages>> GetPageBehaviors(string viewId, DateRange dateRange, List<Dimension> dimensions, List<Metric> metrics, string FiltersExpression = null, Credential credential = null)
        {
            var responData = new List<SiteContentAllPages>();
            try
            {
                var reportRequest = new ReportRequest
                {
                    DateRanges = new List<DateRange> { dateRange },
                    Metrics = metrics,
                    Dimensions = dimensions,
                    FiltersExpression = FiltersExpression,
                    ViewId = viewId
                };
                var getReportsRequest = new GetReportsRequest
                {
                    ReportRequests = new List<ReportRequest> { reportRequest }
                };

                var analyticsService = GAReportService.GetAnalyticsReportingServiceInstance(credential.Data.client_Id, credential.Data.client_secret);
                var response = await (analyticsService.Reports.BatchGet(getReportsRequest)).ExecuteAsync();
                if (response != null)
                {
                    responData = response.Reports[0].Data.Rows.Select(row => new SiteContentAllPages()
                    {
                        PageTitle = row.Dimensions[0],
                        PagePath = row.Dimensions[1],
                        Date = Convert.ToDateTime(DateTime.ParseExact( row.Dimensions[2].ToString(), "yyyyMMdd",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None).ToString("yyyy-MM-dd")),
                        UniquePageViews = Convert.ToInt64(row.Metrics[0].Values[0])
                    }).ToList(); ;
                }
                return responData;
            }
            catch (Exception ex)
            {
                
            }
            return responData;
        }

    }
}
