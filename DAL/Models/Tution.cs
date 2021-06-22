using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Tution
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        //[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string CreaterId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string AppliedBy { get; set; }
        public string ApprovedTo { get; set; }
    }
}
