using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IRetriever
    {
        IEnumerable<User> RetrieveUsers(IEnumerable<Csv> users);
    }
}