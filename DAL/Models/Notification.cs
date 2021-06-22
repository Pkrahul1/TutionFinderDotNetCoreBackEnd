using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Notification
    {
        
        public int Id { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string Msg { get; set; }
    }
}
