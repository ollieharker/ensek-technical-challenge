using CsvHelper;
using Ensek.TechnicalTest.Api.Extensions;
using Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading;
using Ensek.TechnicalTest.Db.Models;
using System.Globalization;

namespace Ensek.TechnicalTest.Api.Tests.Extensions
{
	public class NewMeterReadDtoExtensionsTests
	{
		public static IEnumerable<object[]> NewMeterReadingDtoTestData()
		{
			yield return new object[] { new NewMeterReadingDto() { DateTime = DateTimeOffset.UtcNow, AccountId = 1234, Value = 632}};
			yield return new object[] { new NewMeterReadingDto() { DateTime = DateTimeOffset.UtcNow.AddDays(-5), AccountId = 4321, Value = 1000 } };
			yield return new object[] { new NewMeterReadingDto() { DateTime = DateTimeOffset.UtcNow.AddDays(365), AccountId = 1, Value = 7 } };
		}

		[Theory]
		[MemberData(nameof(NewMeterReadingDtoTestData))]
		public void ToMeterReadingGivenDtoAssignesDateTime(NewMeterReadingDto newMeterReadingDto)
		{
			var meterReading = newMeterReadingDto.ToMeterReading();

			Assert.Equal(newMeterReadingDto.DateTime, meterReading.DateTime);
		}

		[Theory]
		[MemberData(nameof(NewMeterReadingDtoTestData))]
		public void ToMeterReadingGivenDtoAssignesAccountId(NewMeterReadingDto newMeterReadingDto)
		{
			var meterReading = newMeterReadingDto.ToMeterReading();

			Assert.Equal(newMeterReadingDto.AccountId, meterReading.AccountId);
		}

		[Theory]
		[MemberData(nameof(NewMeterReadingDtoTestData))]
		public void ToMeterReadingGivenDtoAssignesValue(NewMeterReadingDto newMeterReadingDto)
		{
			var meterReading = newMeterReadingDto.ToMeterReading();

			Assert.Equal(newMeterReadingDto.Value, meterReading.Value);
		}

		[Fact]
		public void ToMeterReadingGivenDtoIdSetToDefault()
		{
			var meterReadingDto = new NewMeterReadingDto();

			var meterReading = meterReadingDto.ToMeterReading();

			Assert.Equal(default(int), meterReading.Id);
		}

		[Fact]
		public void ToMeterReadingGivenDtoAccountSetToNull()
		{
			var meterReadingDto = new NewMeterReadingDto();

			var meterReading = meterReadingDto.ToMeterReading();

			Assert.Null(meterReading.Account);
		}
	}
}
