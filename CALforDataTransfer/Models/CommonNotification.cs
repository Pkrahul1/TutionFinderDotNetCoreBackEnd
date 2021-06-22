using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CALforDataTransfer.Models
{
    public class CommonNotification
    {
        public int? Id { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string Msg { get; set; }
    }
}
