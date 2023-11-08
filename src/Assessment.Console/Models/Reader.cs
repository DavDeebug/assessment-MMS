﻿using Assessment.Console.Abstract;
using Assessment.Console.Options;
using Microsoft.Extensions.Options;

namespace Assessment.Console.Models;

public class Reader : IReaderAsync
{
    readonly ReaderOptions _options;

    public Reader(IOptions<ReaderOptions> options) => _options = options.Value;

    public async Task<IEnumerable<Csv>> ReadUsersAsync(string filePath)
    {
        var lines =  await File.ReadAllLinesAsync(Path.Combine(filePath,
            string.Format(_options.FileName, _options.Extension)));
        var users = lines
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(line =>
            {
                var split = line.Split(_options.Separator);
                var givenName = split[0].Trim();
                var familyName = split[1].Trim();
                return new Csv(givenName, familyName);
            });

        return users;
    }
}