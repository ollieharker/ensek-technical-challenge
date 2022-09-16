using Ensek.TechnicalTest.Api.Dto;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public interface IMeterReadCsvUploadService
	{
		public MeterReadingUploadResult UploadMeterReadsFromStream(Stream stream);
	}
}