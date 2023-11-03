

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.CSV;
using web_api.DataAccess;
using web_api.DataAccess.Repository;

namespace Business.MeterReadings.Validation
{
    public class ValidAccountNumber : IValidAccountNumber
    {
        private readonly IRepository<Account> accountRepository;
        private IDictionary<int, MeterReadingLine> missingAccountNumbers; 

        public ValidAccountNumber(IRepository<Account> accountRepository) {
            this.accountRepository = accountRepository;
        }
        
        public Task<bool> IsValid(MeterReadingLine meterReadingLine) {
            
            return accountRepository.Exists(a => meterReadingLine.AccountId == a.Id);

        }
    }
}