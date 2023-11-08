using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Shared;
using System.Text.Json;
using System.Web;

namespace Assessment.Console.Models;

public class Retriever : IRetrieverAsync
{        
    readonly AssessmentClient _client;

    public Retriever(AssessmentClient client) => _client = client;

    public async Task<IEnumerable<User>> RetrieveUsersAsync(IEnumerable<Csv> users)
    {
        var completeUsers = new List<User>();
        foreach (var user in users)
        {
            var builder = HttpUtility.ParseQueryString(string.Empty);

            builder.Add("given-name", user.GivenName);
            builder.Add("family-name", user.FamilyName);            

            var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
            var response = await _client.GetAsync(request);

            using var stream = await response.Content.ReadAsStreamAsync();            
            var completeUser =  await JsonSerializer.DeserializeAsync<User>(stream);

            if (completeUser is null) continue;

            completeUsers.Add(completeUser);
        }

        return completeUsers;
    }
}