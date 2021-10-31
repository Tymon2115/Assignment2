using AdultDataAPI.Models;

namespace AdultDataAPI.Data{
    public interface IUserService{
        User ValidateUser(string userName, string password);
    }
}