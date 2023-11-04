using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IRetriever
    {
        IEnumerable<User> RetrieveUsers();
    }

}
