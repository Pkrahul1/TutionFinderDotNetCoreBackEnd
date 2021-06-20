using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        //[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage = "Invalid Email Format")]
        //[Display(Name = "Office Email")]
        public string Email { get; set; }
        public string Skills { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
