using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Surprise_Test.Models;

namespace Surprise_Test.Data 
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Preferred_Job> Preferred_Jobs { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Payout> Payouts { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Office_Address> Office_Addresses { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Existing_Job> Existing_Jobs { get; set; }
        public DbSet<Job_Posting> Job_Postings { get; set; }
        public DbSet<Incentive> Incentives { get; set; }
        public DbSet<Leisure> Leisures { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job_Application> Job_Applications{ get; set; }
    }
}