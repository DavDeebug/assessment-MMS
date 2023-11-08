using Assessment.Console.Abstract;
using Assessment.Shared;
using static System.Console;

namespace Assessment.Console
{
    public class Worker
    {        
        readonly IReaderAsync _reader;
        readonly IRetrieverAsync _retriever;
        readonly IWriterAsync _writer;        

        public Worker(IReaderAsync reader, IRetrieverAsync retriever, IWriterAsync writer)
        {
            _reader = reader;
            _retriever = retriever;
            _writer = writer;
        }

        public async Task Work(string filePath)
        {
            try
            {                
                var users = await _reader.ReadUsersAsync(filePath);
                
                var completeUsers = await _retriever.RetrieveUsersAsync(users) ?? Enumerable.Empty<User>();
                
                await _writer.WriteUsersAsync(completeUsers, filePath);

                WriteLine("Done!");
            }
            catch (Exception e)
            {
                WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}