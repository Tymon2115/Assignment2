using System.Collections.Generic;
using FamilyData.Models;

namespace Models {
public class Child : Person {
    
    public List<Interest> Interests { get; set; }
    public List<Pet> Pets { get; set; }
}
}