using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdultDataAPI.Models {
    public class Job {
        [StringLength(20, ErrorMessage = "Enter valid Job title")]
        [MinLength(2)]
        [Required] 
        [JsonPropertyName("JobTitle")]
        public string JobTitle { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter the correct monthly salary")]
        [JsonPropertyName("Salary")]
        public int Salary { get; set; }
    }
}