using CRM.Application.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CustomerDbContext
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options): base(options) { }
        public DbSet<CustomerViewModel> Customers { get; set; }
    }
}
