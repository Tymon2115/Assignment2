using System.ComponentModel.DataAnnotations;

namespace AdultDataAPI.Models {
    public class Person {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        public string LastName { get; set; }

        [Required] public string HairColor { get; set; }
        [Required] public string EyeColor { get; set; }

        [Range(0, 120, ErrorMessage = "Please enter the correct age")]
        public int Age { get; set; }

        [Range(40, 350, ErrorMessage = "Please enter the correct weight")]
        public float Weight { get; set; }

        [Range(70, 250, ErrorMessage = "Please enter the correct height")]
        public int Height { get; set; }

        [Required] public string Sex { get; set; }
    }
}