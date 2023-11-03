
using System;

namespace Model.CSV
{
    public class MeterReadingLine {

        public int AccountId {get; set;}

        public DateTime MeterReadingDateTime { get; set;}
        
        public string MeterReadValue {get; set; }
    }
}