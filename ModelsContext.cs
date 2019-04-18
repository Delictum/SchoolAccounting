using System.Data.Entity;
using SchoolAccounting.Models;

namespace SchoolAccounting
{
    class ModelsContext : DbContext
    {
        public ModelsContext()
            : base("DbConnection")
        { }

        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}
