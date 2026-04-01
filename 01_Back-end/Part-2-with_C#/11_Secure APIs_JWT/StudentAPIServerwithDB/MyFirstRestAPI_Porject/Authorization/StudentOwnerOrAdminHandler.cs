using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace StudentApi.Authorization
{
    public class StudentOwnerOrAdminHandler : AuthorizationHandler<StudentOwnerOrAdminRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, StudentOwnerOrAdminRequirement requirement, int StudentID)
        {
           if(context.User.IsInRole("Admin"))
           {
               context.Succeed(requirement);
               return Task.CompletedTask;
           }

           var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(int.TryParse(userId, out int authenticatedUserID) && authenticatedUserID == StudentID)
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}
