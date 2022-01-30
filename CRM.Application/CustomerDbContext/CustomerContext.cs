using CRM.Application.Models.Customer;
using CRM.Application.Models.User;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CustomerDbContext
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options): base(options) { }
        public DbSet<CustomerViewModel> Customers { get; set; }
        public DbSet<UserViewModel> Users { get; set; }
    }
}
