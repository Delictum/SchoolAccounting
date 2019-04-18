namespace SchoolAccounting.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public double MadeBy { get; set; }

        public Payment Payment { get; set; }
    }
}
