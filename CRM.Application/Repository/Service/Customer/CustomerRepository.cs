using CRM.Application.CustomerDbContext;
using CRM.Application.Models.Customer;
using CRM.Application.Repository.Interface.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Repository.Service.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext customerContext;

        public CustomerRepository(CustomerContext _customerContext)
        {
            this.customerContext = _customerContext;
        }

        [Authorize]
        public async Task<CustomerViewModel> AddCustomer(CustomerViewModel customer)
        {
             await customerContext.Customers.AddAsync(customer);
            await customerContext.SaveChangesAsync();
            return customer;
        }

        [Authorize]
        public async Task DeleteCustomer(int id)
        {
            var result = await customerContext.Customers.FirstOrDefaultAsync
                (
                    x=> x.CustomerId == id);
            customerContext.Customers.Remove(result);
            await customerContext.SaveChangesAsync();   
        }
        [Authorize]
        public async Task<CustomerViewModel> GetCustomer(int id)
        {
            var result = await customerContext.Customers.FirstOrDefaultAsync
               (
                   x => x.CustomerId == id);
            return result;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> GetCustomerList()
        {
            var customerList = await customerContext.Customers.ToListAsync();
            return customerList;

        }

        [Authorize]
        public async Task<CustomerViewModel> UpdateCustomer(CustomerViewModel customer)
        {
            var result = await customerContext.Customers.FirstOrDefaultAsync(
                    x => x.CustomerId == customer.CustomerId);
            if(result != null)
            {
                result.CustomerName = customer.CustomerName;
                await customerContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
