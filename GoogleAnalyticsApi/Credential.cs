using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsApi
{
 
   public class Credential
    {
        [JsonProperty("installed")]
        public Web Data { get; set; }
    }
    public class Web
    {
        [JsonProperty("client_id")]
        public string client_Id { get; set; }
        [JsonProperty("client_secret")]
        public string client_secret { get; set; }
    }
}
