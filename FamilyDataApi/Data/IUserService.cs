using System.Threading.Tasks;
using AdultDataAPI.Models;

namespace AdultDataAPI.Data{
    public interface IUserService{
        Task<User> ValidateUser(string userName, string password);
    }
}