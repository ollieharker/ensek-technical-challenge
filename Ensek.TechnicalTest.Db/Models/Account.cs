namespace Ensek.TechnicalTest.Db.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<MeterReading> Readings { get; set; }
    }
}
