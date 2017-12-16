using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_EF1.Models
{
    public class Student
    {
        [Required]
        [Range(0,int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Surname { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }
        public string Status { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id.ToString() == "")
            {
                yield return new ValidationResult("Enter student's id.", new[] { nameof(Id)});
            }
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Enter student's name.", new[] { nameof(Name) });
            }
            if (string.IsNullOrEmpty(Surname))
            {
                yield return new ValidationResult("Enter student's surame.", new[] { nameof(Surname) });
            }
        }



    }
}