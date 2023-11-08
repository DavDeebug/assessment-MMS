using Assessment.Console.Abstract;
using Assessment.Console.Options;
using Assessment.Shared;
using Microsoft.Extensions.Options;
using static System.Console;

namespace Assessment.Console.Models;

public class Writer : IWriter
{
    readonly WriterOptions _options;    

    public Writer(IOptions<WriterOptions> options) => _options = options.Value;

    public void Write(IEnumerable<User> completeUsers, string filePath)
    {
        if (!completeUsers.Any())
        {
            WriteLine("No users found!");
            return;
        }

            File.WriteAllLines(Path.Combine(filePath,
                string.Format(_options.FileName, DateTime.Now.ToString(_options.DateFormat), _options.Extension)),
                completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
    }
}