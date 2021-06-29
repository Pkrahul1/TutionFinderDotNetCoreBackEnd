using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CALforDataTransfer.CustomeValidation
{
    public class ValidateDomainAttribute:ValidationAttribute
    {
        private readonly string[] validDomains;

        public ValidateDomainAttribute(string[] validDomains)
        {
            this.validDomains = validDomains;
        }
        public override bool IsValid(object value)
        {
            string[] strings= value.ToString().Split("@");
            string domain = strings[1].ToUpper();
            return validDomains.Contains(domain); 
        }
    }
}
