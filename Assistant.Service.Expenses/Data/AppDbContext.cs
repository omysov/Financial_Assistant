using Assistans.Service.ExpensesAPI.Models;
using Assistans.Service.ExpensesAPI.Models;
using Assistant.Service.ExpensesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assistant.Service.ExpensesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Expenses> expenses { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Expenses>().HasData(new Expenses
            {

            });
        }
    }
}
