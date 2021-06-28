using System;
using System.Collections.Generic;
using System.Text;

namespace CALforDataTransfer.ViewModels
{
    public class ManageUserViewModel
    {
        public IList<string> Roles { get; set; }
        public IList<string> Claims { get; set; }
    }
}
