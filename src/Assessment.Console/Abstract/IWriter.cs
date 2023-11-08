using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IWriter
    {
        void Write(IEnumerable<User> completeUsers, string filePath);
    }
}