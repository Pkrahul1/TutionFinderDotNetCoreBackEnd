using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayerAPI.CustomeRequirements
{
    public class OnlyMeRequirement : IAuthorizationRequirement
    {

    }
}
