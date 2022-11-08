using Lab3.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace Lab3.Booking.Steps
{
    [Binding]
    public class UpdateBookingSteps : BaseBookingSteps
    {
        private RestRequest request;
        private RestResponse response;
        private string AuthToken;
        private int id;
        [Given("token and id for update booking")]
        public void GivenTokenAndIdForUpdate()
        {
            var authRequest = new RestRequest("auth", Method.Post);
            authRequest.AddJsonBody(new { username = "admin", password = "password123" });
            var authResponse = client.Execute(authRequest);
            AuthToken = JsonConvert.DeserializeObject<TokenModel>(authResponse.Content).Token;
            id = JsonConvert.DeserializeObject<List<BookingIdModel>>(client.Execute(new RestRequest("booking?firstname=Jim", Method.Get)).Content).First().BookingId;
        }
        [When("create update booking and send request")]
        public void WhenUpdateBooking()
        {
            request = new RestRequest($"booking/{id}", Method.Put);
            request.AddHeaders(new Dictionary<string, string> {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Cookie", $"token={AuthToken}"}
            });

            request.AddJsonBody(new
            {
                firstname = "Philip",
                lastname = "Touring",
                totalprice = 153,
                depositpaid = true,
                bookingdates = new { checkin = "2020-01-01", checkout = "2021-01-01" },
                additionalneeds = "Lunch"
            });
            response = client.Execute(request);
        }
        [Then(@"booking is updated")]
        public void ThenResponseIsSuccess()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
