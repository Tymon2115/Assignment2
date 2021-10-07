using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models {
    public class Job {
        [Required] public string JobTitle { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter the correct monthly salary")]
        public int Salary { get; set; }
    }
}