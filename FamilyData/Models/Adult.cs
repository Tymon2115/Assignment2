using System.Text.Json.Serialization;

namespace FamilyData.Models {
public class Adult : Person {
    [JsonPropertyName("JobTitle")]
    public Job JobTitle { get; set; }
}
}