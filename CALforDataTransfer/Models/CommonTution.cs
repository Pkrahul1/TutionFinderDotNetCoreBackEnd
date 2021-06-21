using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CALforDataTransfer.Models
{
    public class CommonTution
    {
        public int? Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string CreaterId { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
