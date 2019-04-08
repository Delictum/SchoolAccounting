namespace SchoolAccounting.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeOfService TypeOfService { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Access { get; set; }
    }
}
