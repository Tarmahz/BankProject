using System.ComponentModel.DataAnnotations;

namespace NewestBankProject.Models
{
    public class AccountRequirements
    {
        [Key]
        public string AccountNumber { get; set; }
        //[ForeignKey("Customer")]
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal CurrentAccountBalance { get; set; }
        public AccountType AccountType { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateLastUpdated { get; set; } = DateTime.Now;

        Random random = new Random();
        public AccountRequirements()
        {
            AccountNumber = Convert.ToString((long)random.NextDouble() * 9_000_000_000L + 1_000_000_000L);
            //AccountName = $"{FirstName} {LastName}";
        }
    }
    public enum AccountType
    {
        Savings,
        Current
    }

}

