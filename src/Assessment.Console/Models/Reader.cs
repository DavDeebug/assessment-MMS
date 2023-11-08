using Assessment.Console.Abstract;
using Assessment.Console.Options;
using Microsoft.Extensions.Options;

namespace Assessment.Console.Models;

public class Reader : IReader
{
    private readonly ReaderOptions _options;

    public Reader(IOptions<ReaderOptions> options) => _options = options.Value;

    public IEnumerable<Csv> GetUsers(string filePath)
    {
        var lines = File.ReadAllLines(Path.Combine(filePath,
            string.Format(_options.FileName, _options.Extension)));
        var users = lines
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(line =>
            {
                var split = line.Split(_options.Separator);
                var givenName = split[0].Trim();
                var familyName = split[1].Trim();
                return new Csv(givenName, familyName);
            });

        return users;
    }
}