using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayerAPI.Customize
{
    public class CustomeTokenProvider<TUser>:DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomeTokenProvider(IDataProtectionProvider dataProtectionProvider,
                                        IOptions<CustomeTokenProviderOtions>options):base(dataProtectionProvider,options)
        {
             
        }
    }
}
