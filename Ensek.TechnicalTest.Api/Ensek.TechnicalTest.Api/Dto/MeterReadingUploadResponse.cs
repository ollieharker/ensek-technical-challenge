namespace Ensek.TechnicalTest.Api.Dto
{
    public class MeterReadingUploadResponse
    {
        public bool Success {get; set;}
        public string Error { get; set; }

        public MeterReadingUploadResult Result { get; set; }

        public static MeterReadingUploadResponse Successful(MeterReadingUploadResult result)
            => new MeterReadingUploadResponse() { Result = result, Success = true, Error = null };

		public static MeterReadingUploadResponse Failure(string errorMessage)
	        => new MeterReadingUploadResponse() { Result = null, Success = false, Error = errorMessage };
    }
}
