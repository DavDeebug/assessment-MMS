using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Shared;
using System.Text.Json;
using System.Web;

namespace Assessment.Console.Models;

public class Retriever : IRetriever
{        
    readonly AssessmentClient _client;

    public Retriever(AssessmentClient client) => _client = client;

    public IEnumerable<User> RetrieveUsers(IEnumerable<Csv> users)
    {
        var completeUsers = new List<User>();
        foreach (var user in users)
        {
            var builder = HttpUtility.ParseQueryString(string.Empty);

            builder.Add("given-name", user.GivenName);
            builder.Add("family-name", user.FamilyName);            

            var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
            var response = _client.Get(request);

            using var stream = response.Content.ReadAsStream();
            var completeUser = JsonSerializer.Deserialize<User>(stream);

            if (completeUser is null) continue;

            completeUsers.Add(completeUser);
        }

        return completeUsers;
    }
}