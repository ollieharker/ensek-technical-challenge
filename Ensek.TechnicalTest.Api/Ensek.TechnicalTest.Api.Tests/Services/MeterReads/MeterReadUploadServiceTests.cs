using Ensek.TechnicalTest.Api.Exceptions;
using Ensek.TechnicalTest.Api.Services.MeterReads;
using Ensek.TechnicalTest.Data.Services.Readings;
using Ensek.TechnicalTest.Db.Models;
using Moq;

namespace Ensek.TechnicalTest.Api.Tests.Services.MeterReads
{
	public class MeterReadUploadServiceTests
	{
		private Mock<IMeterReadCsvParser> mockReadCsvParser;
		private Mock<IMeterReadingDataService> mockMeterReadingService;
		private MeterReadCsvUploadService sut;

		public MeterReadUploadServiceTests()
		{
			this.mockReadCsvParser = new Mock<IMeterReadCsvParser>();
			this.mockMeterReadingService = new Mock<IMeterReadingDataService>();

			this.SetupMinimumReadingUpload();

			this.sut = new MeterReadCsvUploadService(this.mockReadCsvParser.Object, this.mockMeterReadingService.Object);
		}

		[Fact]
		public void GivenNullStreamThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => this.sut.UploadMeterReadsFromStream(null));
		}

		[Fact]
		public void GivenCsvParserThrowsExceptionMeterReadUploadExceptionThrownWithInnerException()
		{
			var expectedException = new Exception("test-exception");
			this.mockReadCsvParser.Setup(mock => mock.ParseCsvToMeterReadings(It.IsAny<Stream>()))
				.Throws<Exception>(() => throw expectedException);

			this.AssertMeterReadExceptionThrownWithInnerException(expectedException);
		}

		[Fact]
		public void GivenUploadMeterServiceThrowsExceptionMeterReadUploadExceptionThrownWithInnerException()
		{
			var expectedException = new Exception("test-exception");
			this.mockMeterReadingService.Setup(mock => mock.AddMeterReadings(It.IsAny<IEnumerable<MeterReading>>()))
				.Throws<Exception>(() => throw expectedException);

			this.AssertMeterReadExceptionThrownWithInnerException(expectedException);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(15)]
		public void GivenResultFromUploadServiceAssignedToUploadsSuccessful(int addedReadingCount)
		{
			this.SetupMeterServiceWithResult(new AddMeterReadingResult { AddedReadingCount = addedReadingCount });

			var result = this.sut.UploadMeterReadsFromStream(new MemoryStream());

			Assert.Equal(addedReadingCount, result.UploadsSuccessful);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(15)]
		public void GivenResultFromUploadServiceAssignedToSaveFailed(int failedToSaveCount)
		{
			this.SetupMeterServiceWithResult(new AddMeterReadingResult { RejectedReadingCount = failedToSaveCount });

			var result = this.sut.UploadMeterReadsFromStream(new MemoryStream());

			Assert.Equal(failedToSaveCount, result.UploadsFailedToSave);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(15)]
		public void GivenResultFromCsvParserAssignedToFailedToParse(int failedToParseCount)
		{
			this.SetupCsvParserWithResult(new MeterReadParsingResult(Enumerable.Empty<MeterReading>(), failedToParseCount));

			var result = this.sut.UploadMeterReadsFromStream(new MemoryStream());

			Assert.Equal(failedToParseCount, result.UploadsFailedToParse);
		}

		private void AssertMeterReadExceptionThrownWithInnerException(Exception expectedInnerException)
		{
			var thrownException = Assert.Throws<MeterReadUploadException>(() => this.sut.UploadMeterReadsFromStream(new MemoryStream()));
			Assert.Equal(expectedInnerException, thrownException.InnerException);
		}

		private void SetupMeterServiceWithResult(AddMeterReadingResult addMeterReadingResult)
			=> this.mockMeterReadingService.Setup(mock => mock.AddMeterReadings(It.IsAny<IEnumerable<MeterReading>>()))
				.Returns(addMeterReadingResult);

		private void SetupCsvParserWithResult(MeterReadParsingResult meterReadParsingResult)
			=> this.mockReadCsvParser.Setup(mock => mock.ParseCsvToMeterReadings(It.IsAny<Stream>()))
				.Returns(meterReadParsingResult);

		private void SetupMinimumReadingUpload()
		{
			this.SetupCsvParserWithResult(new MeterReadParsingResult(new List<MeterReading>(), 0));

			this.SetupMeterServiceWithResult(new AddMeterReadingResult());
		}
	}
}
