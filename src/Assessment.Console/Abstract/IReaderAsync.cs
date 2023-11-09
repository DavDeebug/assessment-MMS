using Assessment.Console.Models;

namespace Assessment.Console.Abstract
{
    public interface IReaderAsync
    {
        IAsyncEnumerable<Csv> ReadUsersAsync(string filePath);        
    }
}