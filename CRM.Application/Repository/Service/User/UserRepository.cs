using CRM.Application.CustomerDbContext;
using CRM.Application.Models.User;
using CRM.Application.Repository.Interface.User;
using System.Threading.Tasks;

namespace CRM.Application.Repository.Service.User
{
    public class UserRepository : IUserRepository
    {

        private readonly CustomerContext customerContext;

        public UserRepository(CustomerContext _customerContext)
        {
            this.customerContext = _customerContext;
        }
        public Task<UserViewModel> UserLogin(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
