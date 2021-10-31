using System.Collections.Generic;
using System.Threading.Tasks;
using AdultDataAPI.Models;

namespace AdultDataAPI.Data {
    public interface IAdultService {
        Task<IList<Adult>> GetAdults();
        Task AddAdult(Adult adult);
        Task RemoveAdult(int id);
        Task EditAdult(Adult adult);
        Task<Adult> Get(int id);
    }
}