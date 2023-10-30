namespace Assessment.Console.Models;

public class Reader
{
    const string separator = ";";
    const string extension = ".txt";    
    private readonly string _path;

    public Reader(string path)
    {
        _path = path ?? string.Empty;
    }

    public IEnumerable<Csv> GetUsers()
    {
        var lines = File.ReadAllLines(Path.Combine(_path!, $"input{extension}"));
        var users = lines
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(line =>
            {
                var split = line.Split(separator);
                var givenName = split[0].Trim();
                var familyName = split[1].Trim();
                return new Csv(givenName, familyName);                            
            });

        return users;
    }
}