using Ensek.TechnicalTest.Api.Dto;
using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;
using Ensek.TechnicalTest.BusinessLogic.Validation;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public interface IMeterReadCsvUploadService
	{
		public MeterReadingUploadResult UploadMeterReadsFromStream(Stream stream);
	}
}