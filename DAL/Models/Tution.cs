using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Tution
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        //[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string CreaterId { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
