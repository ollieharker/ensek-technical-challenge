namespace Ensek.TechnicalTest.Api.Exceptions
{
	[Serializable]
	public class MeterReadParsingException : Exception
	{
		public MeterReadParsingException() { }
		public MeterReadParsingException(string message) : base(message) { }
		public MeterReadParsingException(string message, Exception inner) : base(message, inner) { }
		protected MeterReadParsingException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
