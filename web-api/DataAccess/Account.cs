
using System.Collections.Generic;


namespace web_api.DataAccess 
{ 
    public class Account {

        public int Id { get; set;}

        public string FirstName {get ;set; }

        public string LastName {get ;set; }

        public ICollection<MeterReading> MeterReadings { get; set; }
    }
}