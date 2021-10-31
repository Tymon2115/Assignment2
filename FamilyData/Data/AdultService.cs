// using System;
// using System.Collections.Generic;
// using System.Linq;
// using FileData;
// using Models;
//
//
// namespace FamilyData.Data {
//     public class AdultService : IAdultService {
//         public IList<Adult> Adults { get; private set; }
//         private FileContext fileContext;
//
//         public AdultService() {
//             fileContext = new FileContext();
//             Adults = fileContext.Adults;
//         }
//
//
//         public void AddAdult(Adult adult) {
//             int max = Adults.Max(adult1 => adult1.Id);
//             adult.Id = (++max);
//             fileContext.Adults.Add(adult);
//             fileContext.SaveChanges();
//         }
//
//         public void RemoveAdult(int id) {
//             fileContext.Adults.Remove(Get(id));
//             fileContext.SaveChanges();
//         }
//
//         public void EditAdult(Adult adult) {
//             throw new System.NotImplementedException();
//         }
//
//         public Adult Get(int id) {
//             return Adults.First((adult => adult.Id == id));
//         }
//     }
// }