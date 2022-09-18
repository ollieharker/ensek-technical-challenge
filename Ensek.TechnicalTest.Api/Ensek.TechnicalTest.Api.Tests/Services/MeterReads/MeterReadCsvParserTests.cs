using ApprovalTests;
using ApprovalTests.Reporters;
using Ensek.TechnicalTest.Api.Exceptions;
using Ensek.TechnicalTest.Api.Services.MeterReads;
using Newtonsoft.Json;
using System.Text;

namespace Ensek.TechnicalTest.Api.Tests.Services.MeterReads
{
	[Trait("IO", "CSV")]
	[UseReporter(typeof(DiffReporter))]
	public class MeterReadCsvParserTests
	{
		private CsvHelperMeterReadCsvParser sut;

		public MeterReadCsvParserTests()
		{
			this.sut = new CsvHelperMeterReadCsvParser();
		}

		[Fact]
		public void GivenNullStreamExceptionThrown()
		{
			Assert.Throws<ArgumentNullException>(() => this.sut.ParseCsvToMeterReadings(null));
		}

		[Fact]
		public void GivenEmptyStreamNoRecordsReturned()
		{
			var result = this.sut.ParseCsvToMeterReadings(new MemoryStream());

			Assert.Empty(result.NewMeterReadings);
		}

		[Fact]
		public void GivenEmptyStreamNoFailedToParseRecords()
		{
			const int expectedFailedParse = 0;

			var result = this.sut.ParseCsvToMeterReadings(new MemoryStream());

			Assert.Equal(expectedFailedParse, result.ParseFailedCount);
		}

		[Fact]
		public void GivenNonCsvTextMeterParseExceptionThrown()
		{
			var bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
			var memoryStream = new MemoryStream(bytes);

			Assert.Throws<MeterReadParsingException>(() => this.sut.ParseCsvToMeterReadings(memoryStream));
		}

		[Fact]
		public void GivenValidCsvRecordsAddedResult()
		{
			const string path = "./Data/MeterReadings/valid-readings.csv";
			this.ParseAndApproveTestCsvFile(path);
		}

		[Fact]
		public void GivenInvalidCsvRecordsBadResultsRemoved()
		{
			const string path = "./Data/MeterReadings/invalid-readings.csv";
			this.ParseAndApproveTestCsvFile(path);
		}

		[Fact]
		public void GivenInvalidAndValidCsvRecordsBadResultsRemoved()
		{
			const string path = "./Data/MeterReadings/readings-mixed-validity.csv";
			this.ParseAndApproveTestCsvFile(path);
		}

		private void ParseAndApproveTestCsvFile(string filePath)
		{
			var fileString = this.LoadCsvFileIntoStream(filePath);

			var result = this.sut.ParseCsvToMeterReadings(fileString);

			Approvals.Verify(JsonConvert.SerializeObject(result, Formatting.Indented));
		}

		private Stream LoadCsvFileIntoStream(string filePath)
		{
			return File.OpenRead(filePath);
		} 
	}
}
