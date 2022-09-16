namespace Ensek.TechnicalTest.Api.Exceptions
{

	[Serializable]
	public class MeterReadUploadException : Exception
	{
		public MeterReadUploadException() { }
		public MeterReadUploadException(string message) : base(message) { }
		public MeterReadUploadException(string message, Exception inner) : base(message, inner) { }
		protected MeterReadUploadException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
