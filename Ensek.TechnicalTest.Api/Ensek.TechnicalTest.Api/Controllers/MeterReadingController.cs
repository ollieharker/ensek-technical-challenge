using Ensek.TechnicalTest.Api.Dto;
using Ensek.TechnicalTest.Api.Exceptions;
using Ensek.TechnicalTest.Api.Services.MeterReads;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ensek.TechnicalTest.Api.Controllers
{
    [ApiController]
    public class MeterReadingController : Controller
    {
        private readonly IMeterReadCsvUploadService meterReadUploadService;

        public MeterReadingController(IMeterReadCsvUploadService meterReadUploadService)
        {
            this.meterReadUploadService = meterReadUploadService;
        }

        /// <summary>
        /// Upload Meter Reads via CSV.
        /// </summary>
        /// <param name="csvFile">The CSV file containing meter reads to process.</param>
        /// <returns><see cref="MeterReadingUploadResponse"/>, containing the <see cref="MeterReadingUploadResponse.Result"/> upload result.</returns>
        [HttpPost]
        [Route("/meter-reading-uploads")]
        public MeterReadingUploadResponse UploadMeterReads([Required]IFormFile csvFile)
        {
            try
            {
				var result = this.meterReadUploadService.UploadMeterReadsFromStream(csvFile.OpenReadStream());
                return MeterReadingUploadResponse.Successful(result);
			}
            catch (MeterReadUploadException ex)
            {
				return MeterReadingUploadResponse.Failure(ex.Message);
			}
		}
	}
}
