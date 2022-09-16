using Ensek.TechnicalTest.Api.Dto;

namespace Ensek.TechnicalTest.Api.Tests.Dto
{
	public class MeterReadUploadResultTests
	{
		public static IEnumerable<object[]> MeterReadUploadTestCases()
		{
			yield return new object[] { new MeterReadingUploadResult() { UploadsSuccessful = 3, UploadsFailedToParse = 2, UploadsFailedToSave = 0 }, 5 };
			yield return new object[] { new MeterReadingUploadResult() { UploadsSuccessful = 0, UploadsFailedToParse = 23, UploadsFailedToSave = 3 }, 26 };
			yield return new object[] { new MeterReadingUploadResult() { UploadsSuccessful = 0, UploadsFailedToParse = 0, UploadsFailedToSave = 0 }, 0 };
		}


		[Theory]
		[MemberData(nameof(MeterReadUploadTestCases))]
		public void GivenSuccessAndFailValuesCorrectTotalUploaded(MeterReadingUploadResult uploadResult, int expectedUploadedCount)
		{
			Assert.Equal(expectedUploadedCount, uploadResult.TotalUploaded);
		}
	}
}
