using System.Collections.Generic;
using FileData;
using Models;


namespace FamilyData.Data {
    public class AdultService : IAdultService {
        public IList<Adult> Adults { get; private set; }

        public AdultService() {
            FileContext fileContext = new FileContext();
            Adults = new List<Adult>(fileContext.Adults);
        }


        public void AddAdult(Adult adult) {
            throw new System.NotImplementedException();
        }

        public void RemoveAdult(int id) {
            throw new System.NotImplementedException();
        }

        public void EditAdult(Adult adult) {
            throw new System.NotImplementedException();
        }

        public Adult Get(int id) {
            throw new System.NotImplementedException();
        }
    }
}