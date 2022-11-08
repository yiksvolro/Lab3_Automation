using Lab3.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Lab3.Dune.Steps
{
    [Binding]
    public class GetQuotesArray : BaseDuneSteps
    {
        private RestRequest request;
        private RestResponse response;
        [Given("request to get array of quotes")]
        public void GivenRequestToGetQuotesArray()
        {
            request = new RestRequest("quotes/5", Method.Get);
            request.AddHeaders(new Dictionary<string, string> {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }
            });
        }
        [When("send request to get array of quotes")]
        public void WhenSendRequestToGetQuotesArray()
        {
            response = client.Execute(request);
        }
        [Then("successful response with equal count of array")]
        public void ThenCountOfArrayIsValid()
        {
            var count = JsonConvert.DeserializeObject<List<QuoteModel>>(response.Content).Count;
            Assert.That(count, Is.EqualTo(5));
        }
    }
}
