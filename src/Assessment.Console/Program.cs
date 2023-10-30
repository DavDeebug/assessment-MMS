using Assessment.Console.Models;
using Assessment.Shared;
using static System.Console;

string? path;

while (true)
    try
    {
        Work();
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }

void Work()
{
    do
    {
        WriteLine("Please enter a valid path, for txt template");
        path = ReadLine();
    } while (string.IsNullOrEmpty(path) || path.Length < 3);

    var reader = new Reader(path);
    var users = reader.GetUsers();

    var retriever = new Retriever(users);
    var completeUsers = retriever.RetrieveUsers() ?? Enumerable.Empty<User>();
    
    var writer = new Writer(completeUsers, path);
    writer.Write();
    WriteLine("Done!");    
}