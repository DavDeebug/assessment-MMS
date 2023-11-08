﻿using Assessment.Console.Abstract;
using Assessment.Shared;
using static System.Console;

namespace Assessment.Console
{
    public class Worker
    {        
        readonly IReader _reader;
        readonly IRetriever _retriever;
        readonly IWriter _writer;        

        public Worker(IReader reader, IRetriever retriever, IWriter writer)
        {
            _reader = reader;
            _retriever = retriever;
            _writer = writer;
        }

        public void Work(string filePath)
        {
            try
            {                
                var users = _reader.GetUsers(filePath);
                
                var completeUsers = _retriever.RetrieveUsers(users) ?? Enumerable.Empty<User>();
                
                _writer.Write(completeUsers, filePath);

                WriteLine("Done!");
            }
            catch (Exception e)
            {
                WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}