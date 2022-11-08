using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace Lab3.Dune.Steps
{
    [Binding]
    public class GetQuoteSteps : BaseDuneSteps
    {
        private RestRequest request;
        private RestResponse response;
        [Given("request to get quote")]
        public void GivenRequestToGetQuote()
        {
            request = new RestRequest("quotes", Method.Get);
            request.AddHeaders(new Dictionary<string, string> {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }
            });
        }
        [When("send request to get quote")]
        public void WhenSendRequestToGetQuote()
        {
            response = client.Execute(request);
        }
        [Then("successful response with quote")]
        public void ThenResponseIsSuccess()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
