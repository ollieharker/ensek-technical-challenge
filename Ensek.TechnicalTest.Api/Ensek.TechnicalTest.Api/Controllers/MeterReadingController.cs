using Ensek.TechnicalTest.Api.Dto;
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

        [HttpPost]
        [Route("/meter-reading-uploads")]
        public MeterReadingUploadResult UploadMeterReads([Required]IFormFile csvFile)
        {
			return this.meterReadUploadService.UploadMeterReadsFromStream(csvFile.OpenReadStream());
		}
	}
}
