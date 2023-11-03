


using System.Collections.Generic;
using System.Threading.Tasks;
using Model.CSV;

namespace Business.MeterReadings.Validation
{

    public interface IValidationRule 
    {
        Task<bool> IsValid(MeterReadingLine meterReadingLine);
    }

}