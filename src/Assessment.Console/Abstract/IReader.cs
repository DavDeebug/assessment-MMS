using Assessment.Console.Models;

namespace Assessment.Console.Abstract
{
    public interface IReader
    {
        IEnumerable<Csv> GetUsers();
    }
}
