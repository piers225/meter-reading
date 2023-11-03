

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Model.CSV;

namespace Model.Result
{
    public class MeterReadingValidation 
    {
        public readonly IEnumerable<MeterReadingLine> Lines;

        public MeterReadingValidation(IEnumerable<MeterReadingLine> lines) {
            this.Lines = lines;
        }

        [JsonIgnore]
        public IEnumerable<MeterReadingLine> ValidMeterReadings => Lines.Where(w => !InvalidMeterReadings.Contains(w));

        private List<MeterReadingLine> InvalidMeterReadings { get; } = new List<MeterReadingLine>();

        public void AddInvalidLine(MeterReadingLine meterReadingLine)
        {
            InvalidMeterReadings.Add(meterReadingLine);
        }

        public int Successful => Lines.Count() - InvalidMeterReadings.Count();

        public int Unsuccessful => InvalidMeterReadings.Count();

    }
}