using static System.Console;

namespace Assessment.Console.Clients
{
    public class AssessmentClient
    {
        private readonly HttpClient _client;

        public AssessmentClient(HttpClient client) => _client = client;

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            var response = _client.Send(request);

            if (!response.IsSuccessStatusCode)            
                WriteLine($"An error occured: {response.ReasonPhrase}");

            return response;
        }
    }
}