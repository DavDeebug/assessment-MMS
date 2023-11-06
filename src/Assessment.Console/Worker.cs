using Assessment.Console.Clients;
using Assessment.Console.Models;
using Assessment.Shared;
using static System.Console;

namespace Assessment.Console
{
    public class Worker
    {
        string? path;
        readonly AssessmentClient _client;

        public Worker(AssessmentClient client) => _client = client;

        public void Work()
        {
            do
            {
                WriteLine("Please enter a valid path, for txt template");
                path = ReadLine();

            } while (string.IsNullOrEmpty(path) || path.Length < 3);

            try
            {
                var reader = new Reader(path);
                var users = reader.GetUsers();

                var retriever = new Retriever(users, _client);
                var completeUsers = retriever.RetrieveUsers() ?? Enumerable.Empty<User>();

                var writer = new Writer(completeUsers, path);
                writer.Write();

                WriteLine("Done!");
            }
            catch (Exception e)
            {
                WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}