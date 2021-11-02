using System.Text.Json.Serialization;

namespace AdultDataAPI.Models {
public class Adult : Person {
    [JsonPropertyName("JobTitle")]
    public Job JobTitle { get; set; }
}
}