using System;

namespace SchoolAccounting.Models
{
    public class Accounting
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }

        public Service Service { get; set; }
        public Client Client { get; set; }
    }
}
