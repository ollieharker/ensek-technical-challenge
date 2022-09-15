namespace Ensek.TechnicalTest.Api.Dto
{
    public record MeterReadUploadResult
    {
        public int TotalUploaded { get; }

        public int UploadsSuccessful { get; }

        public int UploadsFailed { get; set; }
    }
}
