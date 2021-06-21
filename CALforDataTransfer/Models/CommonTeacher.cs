using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CALforDataTransfer.Models
{
    public class CommonTeacher
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Skills { get; set; }
        public string About { get; set; }
        public Gender Gender { get; set; }
    }
}
