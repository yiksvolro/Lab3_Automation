using RestSharp;
using TechTalk.SpecFlow;

namespace Lab3.Dune.Steps
{
    [Binding]
    public class BaseDuneSteps
    {
        protected static RestClient client { get; set; }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            client = new RestClient("https://the-dune-api.herokuapp.com/");
        }
    }
}
