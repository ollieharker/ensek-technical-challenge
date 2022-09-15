using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;
using Ensek.TechnicalTest.Db.Models;

namespace Ensek.TechnicalTest.Api.Extensions
{
	public static class NewMeterReadingDtoExtensions
	{
		public static MeterReading ToMeterReading(this NewMeterReadingDto dto)
		{
			return new MeterReading()
			{
				DateTime = dto.DateTime,
				AccountId = dto.AccountId,
				Value = dto.Value
			};
		}
	}
}
