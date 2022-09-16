namespace Ensek.TechnicalTest.BusinessLogic.Dto.MeterReading
{
	public class NewMeterReadingDto
	{
		public int AccountId { get; set; }

		public DateTimeOffset DateTime { get; set; }

		public uint Value { get; set; }
	}
}
