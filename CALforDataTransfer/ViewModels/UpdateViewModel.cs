using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CALforDataTransfer.ViewModels
{
    public class UpdateViewModel
    {
        public string City { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Skills { get; set; }
        public string About { get; set; }
        public char Gender { get; set; }

        #region [These validation can be performed at client side]
        //[EmailAddress]
        //[DataType(DataType.Password)]
        //[Display(Name ="Give Same Password as Above")]
        //[Compare("Password",ErrorMessage="Password didn't match")]
        //[Key]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage = "Invalid Email Format")]
        //[Display(Name = "Office Email")]
        //[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        #endregion
    }
}
