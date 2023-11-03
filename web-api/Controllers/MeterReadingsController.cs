using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Upload;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/meter-readings-upload")]
    public class MeterReadingsController : ControllerBase
    {
        private readonly IMeterReadingsService meterReadingsService;
        private readonly ICsvParserService csvParserService;

        private readonly ILogger<MeterReadingsController> logger;

        public MeterReadingsController(IMeterReadingsService meterReadingsService, ICsvParserService csvParserService, ILogger<MeterReadingsController> logger) {
            this.meterReadingsService = meterReadingsService;
            this.csvParserService = csvParserService;
            this.logger = logger;
        }
    
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] CSVUploadForm form)
        {
            var csvLines = this.csvParserService.Parse(form.CsvFile.OpenReadStream());

            if (!csvLines.Any())
            {
                logger.LogWarning("No Valid Lines passed");
                return BadRequest();
            }

            var validation = await this.meterReadingsService.Validate(csvLines);

            await this.meterReadingsService.InsertMeterReadings(validation.ValidMeterReadings);

            return Ok(validation);
        } 
    
    }

}