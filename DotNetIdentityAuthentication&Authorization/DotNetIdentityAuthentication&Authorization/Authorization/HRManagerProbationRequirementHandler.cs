using Microsoft.AspNetCore.Authorization;

namespace DotNetIdentityAuthentication_Authorization.Authorization
{
    public class HRManagerProbationRequirementHandler : Microsoft.AspNetCore.Authorization.AuthorizationHandler<HRManagerProbationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
            {
                return Task.CompletedTask; 
            }

            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);
            var period = DateTime.Now - empDate;

            if (period.Days > 30 * requirement.probationMonths)
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}
