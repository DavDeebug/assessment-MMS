using Assessment.Console.Models;

namespace Assessment.Console.Abstract
{
    public interface IReaderAsync
    {
        Task<IEnumerable<Csv>> ReadUsersAsync(string filePath);
    }
}