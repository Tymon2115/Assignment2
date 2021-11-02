using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdultDataAPI.Models {
    public class Person {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("HairColor")]
        [Required] public string HairColor { get; set; }
        [JsonPropertyName("EyeColor")]
        [Required] public string EyeColor { get; set; }

        [Range(0, 120, ErrorMessage = "Please enter the correct age")]
        [JsonPropertyName("Age")]
        public int Age { get; set; }

        [Range(40, 350, ErrorMessage = "Please enter the correct weight")]
        [JsonPropertyName("Weight")]
        public float Weight { get; set; }

        [Range(70, 250, ErrorMessage = "Please enter the correct height")]
        [JsonPropertyName("Height")]
        public int Height { get; set; }
        [JsonPropertyName("Sex")]
        [Required] public string Sex { get; set; }
    }
}