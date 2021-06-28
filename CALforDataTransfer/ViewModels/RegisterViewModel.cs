using CALforDataTransfer.CustomeValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CALforDataTransfer.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [ValidateDomainAttribute(validDomains:new string[] { "gmail.com", "yahoo.com" })]//ErrorMessage ="We only accept gmail and yahoo Account")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Required]
        public string City { get; set; }
    }
}
