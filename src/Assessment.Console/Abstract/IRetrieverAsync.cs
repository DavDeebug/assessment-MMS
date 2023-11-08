using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IRetrieverAsync
    {
        Task<IEnumerable<User>> RetrieveUsersAsync(IEnumerable<Csv> users);
    }
}