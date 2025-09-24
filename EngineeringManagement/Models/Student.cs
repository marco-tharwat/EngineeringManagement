using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EngineeringManagement.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("Full Name")]
        [MinLength(15)]
        [MaxLength(50, ErrorMessage = "Full name cannot exceed 50 characters.")]
        public string FullName { get; set; }

        [ValidateNever] // This fixes the validation issue
        public Department Department { get; set; }

        [DisplayName("Year of Study")]
        [Range(1, 5, ErrorMessage = "Year of study must be between 1 and 5.")]
        public int YearOfStudy { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Please select a department")]
        public int DepartmentId { get; set; }
    }
}