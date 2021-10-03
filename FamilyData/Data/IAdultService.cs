using System.Collections.Generic;
using Models;

namespace FamilyData.Data {
    public interface IAdultService {
        IList<Adult> Adults { get;}
        void AddAdult(Adult adult);
        void RemoveAdult(int id);
        void EditAdult(Adult adult);
        Adult Get(int id);
    }
}