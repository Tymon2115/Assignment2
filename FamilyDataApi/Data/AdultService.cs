using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AdultDataAPI.Models;
using AdultDataAPI.Persistence;

namespace AdultDataAPI.Data {
    public class AdultService : IAdultService {
        public IList<Adult> Adults { get; private set; }
        private FileContext fileContext;

        public AdultService() {
            fileContext = new FileContext();
            Adults = fileContext.Adults;
        }


        public async Task<IList<Adult>> GetAdults() {
            List<Adult> tmp = new List<Adult>(Adults);
            return tmp;
        }

        public async Task AddAdult(Adult adult) {
            int max = Adults.Max(adult1 => adult1.Id);
            adult.Id = (++max);
            fileContext.Adults.Add(adult);
            fileContext.SaveChanges();
        }

        public async Task RemoveAdult(int id) {
            fileContext.Adults.Remove(Adults.FirstOrDefault(adult => adult.Id == id));
            fileContext.SaveChanges();
        }

        public async Task EditAdult(Adult adult) {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> Get(int id) {
            Adult adult = Adults.FirstOrDefault(adult1 => adult1.Id == id);
            return adult;
        }
    }
}