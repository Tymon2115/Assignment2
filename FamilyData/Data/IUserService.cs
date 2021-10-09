using Models;

namespace FamilyData.Data{
    public interface IUserService{
        User ValidateUser(string userName, string password);
    }
}