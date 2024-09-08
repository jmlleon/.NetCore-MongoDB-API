
using System.ComponentModel.DataAnnotations;

namespace Domain_Layer.DTO
{
    public class StudentDTO
    {
        //[Required(ErrorMessage ="The Title Field is Required")]
        public string Id { get; set; } = "";
        [Required(ErrorMessage ="The Message Field is Required")]
        public string Name { get; set; } = "";
        
        [Required, Range(1,150, ErrorMessage ="The Age must be between 1 and 150 years old")]
        public int Age { get; set; } = 0;
        
    }
}
