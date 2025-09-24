using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EngineeringManagement.Models
{
    public class Department
    {

        public int Id { get; set; }
        [MinLength(2)]
        [MaxLength(7)]
        public string Name { get; set; }
        [MinLength(15)]
        [MaxLength(200)]
        public string Description { get; set; }
        [ValidateNever]
        public List<Student> Students { get; set; }
        [ValidateNever]
        public List<Professor> Professors { get; set; }
    }
}
