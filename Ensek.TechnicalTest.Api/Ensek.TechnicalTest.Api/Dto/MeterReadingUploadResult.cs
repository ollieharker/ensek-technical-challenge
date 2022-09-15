namespace Ensek.TechnicalTest.Api.Dto
{
    public record MeterReadingUploadResult
    {
        public int TotalUploaded => UploadsSuccessful + UploadsFailedToParse + UploadsFailedToSave;

        public int UploadsSuccessful { get; set; }

        public int UploadsFailedToParse { get; set; }

		public int UploadsFailedToSave { get; set; }
	}
}
