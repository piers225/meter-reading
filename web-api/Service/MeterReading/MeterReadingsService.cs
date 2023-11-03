

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.MeterReadings.Validation;
using Microsoft.Extensions.Logging;
using Model.CSV;
using Model.Result;
using web_api.DataAccess;
using web_api.DataAccess.Repository;

public class MeterReadingsService : IMeterReadingsService {

    private readonly IRepository<MeterReading> meterReadingRepository;
    private readonly IValidationRule[] validationRules;

    private readonly ILogger<MeterReadingsService> logger;

    public MeterReadingsService(
        IRepository<MeterReading> meterReadingRepository, 
        IIsValidMeterReading isValidMeterReading,
        IIsUniqueReading isUniqueReading,
        IValidAccountNumber isValidAccountNumber,
        ILogger<MeterReadingsService> logger
)
    {
        this.meterReadingRepository = meterReadingRepository;   
        this.validationRules = new IValidationRule[] {
            isValidMeterReading,
            isUniqueReading,
            isValidAccountNumber
        };

        this.logger = logger;
    }

    public Task InsertMeterReadings(IEnumerable<MeterReadingLine> meterReadingLines ) 
    {
        meterReadingRepository.AddRange(
            meterReadingLines.Select(s => new MeterReading() {
                AccountId = s.AccountId,
                ReadingDate = s.MeterReadingDateTime,
                Reading = int.Parse(s.MeterReadValue)
            }).ToArray());

        return meterReadingRepository.Save();
    }

    public async Task<MeterReadingValidation> Validate( IEnumerable<MeterReadingLine> meterReadingLines ) 
    {
        var validation = new MeterReadingValidation(meterReadingLines);

        foreach(var line in meterReadingLines) 
        {
            foreach(var rule in validationRules) 
            {
                if (!(await rule.IsValid(line))) 
                {
                    validation.AddInvalidLine(line);
                    logger.LogWarning("Invalid Line {0} {1} {2} because {3}", line.AccountId, line.MeterReadingDateTime, line.MeterReadValue, rule.GetType().Name);
                    break;
                }
            }    

        }

        return validation;
    }
     
}