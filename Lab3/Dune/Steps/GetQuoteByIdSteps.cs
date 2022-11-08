using Lab3.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Lab3.Dune.Steps
{
    [Binding]
    public class GetQuoteByIdSteps : BaseDuneSteps
    {
        private RestRequest request;
        private RestResponse response;
        [Given("request to get quote by id")]
        public void GivenRequestToGetQuote()
        {
            request = new RestRequest("quotes/id/216", Method.Get);
            request.AddHeaders(new Dictionary<string, string> {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }
            });
        }
        [When("send request to get quote by id")]
        public void WhenSendRequestToGetQuote()
        {
            response = client.Execute(request);
        }
        [Then("successful response with quote by id")]
        public void ThenResponseIsSuccess()
        {
            var quote = JsonConvert.DeserializeObject<QuoteModel>(response.Content).Quote;
            Assert.That(quote, Is.EqualTo("We pray to a moon: she is round luck with us will then abound, what we seek for shall be found in the land of solid ground."));
        }
    }
}
