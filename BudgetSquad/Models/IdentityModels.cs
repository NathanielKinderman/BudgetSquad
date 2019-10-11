using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BudgetSquad.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public DbSet<Planner> Planner { get; set; }
        public DbSet<PartyMember> PartyMemeber { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BudgetSquad.Models.Planner> Planners { get; set; }

        //public System.Data.Entity.DbSet<BudgetSquad.Models.ApplicationUser> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<BudgetSquad.Models.PartyMember> PartyMembers { get; set; }

        public System.Data.Entity.DbSet<BudgetSquad.Models.CreateEvent> CreateEvents { get; set; }

        public System.Data.Entity.DbSet<BudgetSquad.Models.MadeActivites> MadeActivites { get; set; }
        public System.Data.Entity.DbSet<BudgetSquad.Models.ActivitesInfo> ActivitesInfos { get; set; }
        //public System.Data.Entity.DbSet<BudgetSquad.Models.BarGraphData> Datas { get; set; }
    }
}