using CRM.Application.Models.User;
using System.Threading.Tasks;

namespace CRM.Application.Repository.Interface.User
{
    public interface IUserRepository
    {
        Task<UserViewModel> UserLogin(string username, string password);
        Tokens Authenticate(UserViewModel users);
    }
}
