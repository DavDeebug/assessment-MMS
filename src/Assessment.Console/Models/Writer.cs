using Assessment.Console.Abstract;
using Assessment.Console.Options;
using Assessment.Shared;
using Microsoft.Extensions.Options;
using static System.Console;

namespace Assessment.Console.Models;

public class Writer : IWriterAsync
{
    readonly WriterOptions _options;    

    public Writer(IOptions<WriterOptions> options) => _options = options.Value;

    public async Task WriteUsersAsync(IAsyncEnumerable<User> completeUsers, string filePath)
    {
        if (!await completeUsers.AnyAsync())
        {
            WriteLine("No users found!");
            return;
        }

        string fileName = string.Format(_options.FileName, DateTime.Now.ToString(_options.DateFormat), _options.Extension);
        await File.WriteAllLinesAsync(Path.Combine(filePath, fileName),
            GetUserInfoAsync(completeUsers).ToBlockingEnumerable());
    }

    private async IAsyncEnumerable<string> GetUserInfoAsync(IAsyncEnumerable<User> users)
    {
        await foreach (var user in users)
        {
            yield return $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}";
        }
    }
}

public static class Extensions
{
    public static async Task<bool> AnyAsync<T>(this IAsyncEnumerable<T> collection)
    {
        await foreach (T _ in collection)
        {
            return true;
        }
        return false;
    }
}