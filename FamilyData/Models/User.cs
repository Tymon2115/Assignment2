using System.Text.Json.Serialization;

namespace Models {
    public class User {
        [JsonPropertyName("UserName")] public string UserName { get; set; }
        [JsonPropertyName("Password")] public string Password { get; set; }
        [JsonPropertyName("Role")] public string Role { get; set; }
    }
}