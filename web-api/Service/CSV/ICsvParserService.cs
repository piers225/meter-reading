

using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Model.CSV;

public interface ICsvParserService
{
    IEnumerable<MeterReadingLine> Parse(Stream stream);
}