using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceLayerAPI.CustomeRequirements
{
    public class OnlyMeRequirementHandler:AuthorizationHandler<OnlyMeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyMeRequirement requirement)
        {

            var authFltrContext = context.Resource as AuthorizationFilterContext;
            if (authFltrContext == null)
            {
                return Task.CompletedTask;
            }
            // string loggedInEmail = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            string loggedInEmail = authFltrContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            string beignEditedUserEmail = authFltrContext.HttpContext.Request.Query["email"];
            if (loggedInEmail != beignEditedUserEmail) 
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
