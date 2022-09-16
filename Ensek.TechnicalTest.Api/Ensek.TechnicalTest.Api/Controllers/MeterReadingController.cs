using CsvHelper;
using CsvHelper.Configuration;
using Ensek.TechnicalTest.Api.Dto;
using Ensek.TechnicalTest.Api.Services.MeterReads;
using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;
using Ensek.TechnicalTest.BusinessLogic.Validation;
using Ensek.TechnicalTest.Db.Context;
using Ensek.TechnicalTest.Db.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ensek.TechnicalTest.Api.Controllers
{
    [ApiController]
    public class MeterReadingController : Controller
    {
        private readonly IMeterReadCsvUploadService meterReadUploadService;

        public MeterReadingController(MeterReadCsvUploadService meterReadUploadService)
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
