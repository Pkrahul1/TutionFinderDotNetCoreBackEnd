using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CALforDataTransfer.Claims
{
    public static class AllClaims
    {
        public static List<Claim> Claims = new List<Claim>()
        {
            //adding key and value as same
            new Claim("Create Role","Create Role"),
            new Claim("Delete Role","Delete Role"),
            new Claim("Create Tution","Create Tution"),
            new Claim("Delete Tution","Delete Tution")
        };
    }
}
