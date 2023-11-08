using static System.Console;

namespace Assessment.Console.Clients
{
    public class AssessmentClient
    {
        readonly HttpClient _client;

        public AssessmentClient(HttpClient client) => _client = client;

        public async Task <HttpResponseMessage> GetAsync(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)            
                WriteLine($"An error occured: {response.ReasonPhrase}");

            return response;
        }
    }
}