
using Microsoft.EntityFrameworkCore;
using MyStock.Models;

namespace DailyExpenses.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
    }
}
