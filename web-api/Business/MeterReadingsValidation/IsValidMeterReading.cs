using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.CSV;
using web_api.DataAccess;
using web_api.DataAccess.Repository;

namespace Business.MeterReadings.Validation
{
    public class IsValidMeterReading : IIsValidMeterReading
    {
        
        public Task<bool> IsValid(MeterReadingLine meterReadingLine)
        { 
            if (!int.TryParse(meterReadingLine.MeterReadValue, out var _))
            {
                return Task.FromResult(false);
            }

            if ( meterReadingLine.MeterReadValue.Length > 5) 
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}