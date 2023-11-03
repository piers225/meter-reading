

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.CSV;
using web_api.DataAccess;
using web_api.DataAccess.Repository;

namespace Business.MeterReadings.Validation
{
    public class IsUniqueReading : IIsUniqueReading
    {
        private readonly IRepository<MeterReading> meterReadingRepository;
        public IsUniqueReading(IRepository<MeterReading> meterReadingRepository) {
            this.meterReadingRepository = meterReadingRepository;
        }

        public async Task<bool> IsValid(MeterReadingLine meterReadingLine)
        {
            var exists = await meterReadingRepository.Exists(a => 
                meterReadingLine.AccountId == a.AccountId && 
                meterReadingLine.MeterReadingDateTime == a.ReadingDate
            );

            return !exists;
        }
    }
}