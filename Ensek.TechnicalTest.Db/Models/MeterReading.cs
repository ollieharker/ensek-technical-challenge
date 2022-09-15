namespace Ensek.TechnicalTest.Db.Models
{
    public class MeterReading
    {
        public int Id { get; set; }

        public Account? Account { get; set; } 

        public DateTimeOffset DateTime { get; set; }

        public uint Value { get; set; }
    }
}
