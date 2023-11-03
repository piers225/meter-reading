

using System.Collections.Generic;
using System.Threading.Tasks;
using Model.CSV;
using Model.Result;

public interface IMeterReadingsService {

    Task InsertMeterReadings(IEnumerable<MeterReadingLine> meterReadingLines ) ;

     Task<MeterReadingValidation> Validate( IEnumerable<MeterReadingLine> meterReadingLines );
}