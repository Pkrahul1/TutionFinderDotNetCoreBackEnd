using System;
using System.Collections.Generic;
using System.Text;

namespace CALforDataTransfer.Models
{
    public class CommonTeacher
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Skills { get; set; }
        public string About { get; set; }
        public Gender Gender { get; set; }
    }
}
