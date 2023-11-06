using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Shared;
using System.Text.Json;
using System.Web;
using static System.Console;

namespace Assessment.Console.Models;

public class Retriever : IRetriever
{    
    readonly IEnumerable<Csv> _users;
    readonly AssessmentClient _client;

    public Retriever(IEnumerable<Csv>? users, AssessmentClient client) 
    {
        _users = users ?? Enumerable.Empty<Csv>();
        _client = client;
    }
    

    public IEnumerable<User> RetrieveUsers()
    {
        var completeUsers = new List<User>();
        foreach (var user in _users)
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