using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Online_razmjena.Data
{
    public class ApplicationUser: IdentityUser
    {
        public int NeProcitano { get; set; } = 0;

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

        //    // Add custom user claims here
        //    userIdentity.AddClaim(new Claim("CustomName", NeProcitano));

        //    return userIdentity;
        //}
    }
}
