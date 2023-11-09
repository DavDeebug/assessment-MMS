using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IRetrieverAsync
    {
        IAsyncEnumerable<User> RetrieveUsersAsync(IAsyncEnumerable<Csv> users);
    }
}