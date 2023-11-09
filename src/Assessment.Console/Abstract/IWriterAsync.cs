using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IWriterAsync
    {
        Task WriteUsersAsync(IAsyncEnumerable<User> completeUsers, string filePath);
    }
}