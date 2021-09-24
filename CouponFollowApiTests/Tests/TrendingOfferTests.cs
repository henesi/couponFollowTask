using CouponFollowApiTests.Configuration;
using CouponFollowApiTests.Models;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CouponFollowApiTests.Tests
{
    public class TrendingOfferTests : HttpClient
    {
        private const string apiUrl = "extension/trendingOffers";

        [OneTimeSetUp]
        public void Setup()
        {
            client.AddDefaultHeader("catc-version", "5.0.0");
        }

        [Test]
        public void Returns_forbidden_without_version_header()
        {
            IRestClient restClient = new RestClient(Config.EnvironmentUrl);
            IRestRequest request = new RestRequest(apiUrl, Method.GET);

            //then
            IRestResponse response = restClient.Execute(request);
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void Returns_list_of_offers()
        {
            IRestRequest request = new RestRequest(apiUrl, Method.GET);
            IRestResponse<List<Offer>> response = client.Execute<List<Offer>>(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Data);
        }

        [Test]
        public void Returns_equal_20_offers()
        {
            IRestRequest request = new RestRequest(apiUrl, Method.GET);
            IRestResponse<List<Offer>> response = client.Execute<List<Offer>>(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(20, response.Data.Count);
        }

        [Test]
        public void Returns_offer_grouped_by_domain_name()
        {
            IRestRequest request = new RestRequest(apiUrl, Method.GET);
            IRestResponse<List<Offer>> response = client.Execute<List<Offer>>(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(20, response.Data.GroupBy(x => x.DomainName).ToList().Count());
        }
    }
}
