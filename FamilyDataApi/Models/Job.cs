using System.ComponentModel.DataAnnotations;

namespace AdultDataAPI.Models {
    public class Job {
        [StringLength(20, ErrorMessage = "Enter valid Job title")]
        [MinLength(2)]
        [Required] public string JobTitle { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter the correct monthly salary")]
        public int Salary { get; set; }
    }
}