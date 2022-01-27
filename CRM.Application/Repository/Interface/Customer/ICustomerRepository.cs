using CRM.Application.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Repository.Interface.Customer
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerViewModel>> GetCustomerList();
        Task<CustomerViewModel> GetCustomer(int id);
        Task<CustomerViewModel> AddCustomer(CustomerViewModel customer);
        Task<CustomerViewModel> UpdateCustomer(CustomerViewModel customer); 
        Task DeleteCustomer(int id);    

    }
}
