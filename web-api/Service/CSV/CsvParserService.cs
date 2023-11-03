

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Model.CSV;

public class CsvParserService : ICsvParserService
{
    private readonly ILogger<CsvParserService> logger;
    private const char SEPERATOR = ',';

    public CsvParserService(ILogger<CsvParserService> logger) {
        this.logger = logger;
    }

    public IEnumerable<MeterReadingLine> Parse(Stream stream)
    {
        using var textReader = new StreamReader(stream);

        return ReadStream(textReader)
            .Skip(1)
            .Where(IsLineValid)
            .Select(ParseMeterReadingLine)
            .ToArray();
    }

    private bool IsLineValid(string line) {
        var rows = line.Split(SEPERATOR);

        if (!int.TryParse(rows.ElementAt(0), out _))
        {
            logger.LogWarning("Unable to parse {0} as Integer", rows.ElementAt(0));
            return false;
        }

        if (!DateTime.TryParse(rows.ElementAt(1), out _))
        {
            logger.LogWarning("Unable to parse {0} as DateTime", rows.ElementAt(1));
            return false;
        }

        return true;
    }

    private  MeterReadingLine ParseMeterReadingLine(string line) {
        var rows = line.Split(SEPERATOR);

        return new MeterReadingLine() {
            AccountId = int.Parse(rows.ElementAt(0)),
            MeterReadingDateTime = DateTime.Parse(rows.ElementAt(1)),
            MeterReadValue = rows.ElementAt(2)
        };
    }

    private IEnumerable<string> ReadStream(TextReader stream) 
    {
        string line;
        while ((line = stream.ReadLine()) != null)
        {
            yield return line;
        }

    }
}