using Assessment.Console.Abstract;
using Assessment.Shared;
using static System.Console;

namespace Assessment.Console.Models;

public class Writer : IWriter
{    
    const string extension = ".txt";
    private readonly string _path;
    private readonly IEnumerable<User> _completeUsers;

    public Writer(IEnumerable<User>? users, string path)
    {
        _path = path;
        _completeUsers = users ?? Enumerable.Empty<User>();
    }

    public void Write()
    {
        if (!_completeUsers.Any())
        {
            WriteLine("No users found!");
            return;
        }

        File.WriteAllLines(Path.Combine(_path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{extension}"),
            _completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
    }
}