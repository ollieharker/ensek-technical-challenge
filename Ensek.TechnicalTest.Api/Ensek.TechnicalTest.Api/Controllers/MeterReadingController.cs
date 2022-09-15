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
using System.Globalization;

namespace Ensek.TechnicalTest.Api.Controllers
{
    [ApiController]
    public class MeterReadingController
    {
        private readonly EnsekDbContext ensekDbContext;
        private readonly IMeterReadCsvUploadService meterReadUploadService;

        public MeterReadingController(EnsekDbContext ensekDbContext, IMeterReadCsvUploadService meterReadUploadService)
        {
            this.ensekDbContext = ensekDbContext;
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
