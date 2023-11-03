

using System;

namespace web_api.DataAccess 
{ 
    public class MeterReading {

        public int Id {get ;set ; }
        public int AccountId {get ; set;}
        public DateTime ReadingDate {get; set;}
        public int Reading {get;set; }
        public Account Accont { get; set; }
    }
}