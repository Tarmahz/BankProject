using Microsoft.EntityFrameworkCore;
using NewestBankProject.Models;

namespace NewestBankProject.Data
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {


        }
        public DbSet<CustomerRequirements>customerRequirements { get; set; }
        public DbSet<AccountRequirements>accountRequirements { get; set; }
        public DbSet<TransactionRequirements>transactionRequirements { get; set; }
    }
}
