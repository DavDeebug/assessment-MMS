using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IWriterAsync
    {
        Task WriteUsersAsync(IEnumerable<User> completeUsers, string filePath);
    }
}