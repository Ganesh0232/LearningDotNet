using Microsoft.AspNetCore.Authorization;

namespace DotNetIdentityAuthentication_Authorization.Authorization
{
    public class HRManagerProbationRequirement : IAuthorizationRequirement
    {
        public readonly int probationMonths;

        public HRManagerProbationRequirement(int probationMonths)
        {
            this.probationMonths = probationMonths;
        }
    }


}
