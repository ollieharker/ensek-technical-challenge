using CsvHelper.Configuration;
using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;

namespace Ensek.TechnicalTest.Api.Services.MeterReads
{
	public class MeterReadingCsvMap : ClassMap<NewMeterReadingDto>
	{
		public MeterReadingCsvMap()
		{
			this.Map(model => model.AccountId).Name("AccountId");
			this.Map(model => model.DateTime).Name("MeterReadingDateTime");
			this.Map(model => model.Value).Name("MeterReadValue");
		}
	}
}
