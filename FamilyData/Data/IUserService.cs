using System.Threading.Tasks;
using Models;

namespace FamilyData.Data{
    public interface IUserService{
        Task<User> ValidateUser(string userName, string password);
    }
}