using Google.Apis.AnalyticsReporting.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsApi
{
    interface IGoogleAnalyticsReportingService
    {
        Task<List<SiteContentAllPages>> GetPageBehaviors(string viewId, DateRange dateRange, List<Dimension> dimensions, List<Metric> metrics, string FiltersExpression = null, Credential credential = null);
       
    }
}
