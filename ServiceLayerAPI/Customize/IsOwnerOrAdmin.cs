using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceLayerAPI.CustomeRequirements
{
    public class IsOwnerOrAdmin: AuthorizationHandler<OnlyMeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyMeRequirement requirement)
        {

            var authFltrContext = context.Resource as AuthorizationFilterContext;
            if (authFltrContext == null)
            {
                return Task.CompletedTask;
            }
            
            if (context.User.IsInRole("Admin") || context.User.IsInRole("Owner"))
            {
                context.Succeed(requirement);
                //for or check use context.Succeed(requirement) for and use context.Fail()
                //if any handler returns succeeded (but none returning failed) requirement will be  satisfied, authorized.
                //if any of handler returns context.Fail(); , control will go to other handler but requirement will be not satisfied, authorization failed.
            }
            return Task.CompletedTask;
        }
    }
}
