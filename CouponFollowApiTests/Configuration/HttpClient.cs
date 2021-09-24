using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CouponFollowApiTests.Configuration
{
    public class HttpClient
    {
        public IRestClient client;

        public HttpClient()
        {
            client = new RestClient()
            {
                BaseUrl = new Uri(Config.EnvironmentUrl)
            };
        }
    }
}
