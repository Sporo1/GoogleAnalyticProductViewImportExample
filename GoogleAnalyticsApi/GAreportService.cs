using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleAnalyticsApi
{
    public static class GAReportService
    {
      public  static AnalyticsReportingService GetAnalyticsReportingServiceInstance(String ClientId,string ClientSecrete)
        {

            var credential =  GoogleWebAuthorizationBroker.AuthorizeAsync(

                clientSecrets: new ClientSecrets
                 {
                     ClientId = ClientId,
                     ClientSecret = ClientSecrete
                 },
                new string[] { AnalyticsReportingService.Scope.AnalyticsReadonly },
                "20932427sx@gmail.com"
               , CancellationToken.None, dataStore:new FileDataStore("GoogleAnalyticsApi")).Result;
           // var responseToken  = googleAuthFlow.DataStore.GetAsync<TokenResponse>("GoogleAnalyticsApi").Result;
            //var responseToken = new TokenResponse
            //{""
            //    AccessToken = "[ANALYTICSTOKEN]",
            //    RefreshToken = "[REFRESHTOKEN]",
            //    Scope = AnalyticsReportingService.Scope.AnalyticsReadonly, //Read-only access to Google Analytics,
            //    TokenType = "Bearer",
            //};

           // var credential = new UserCredential(googleAuthFlow, "", responseToken);

            // Create the  Analytics service.
            return new AnalyticsReportingService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "FirtShop",
            });
        }
    }
}
