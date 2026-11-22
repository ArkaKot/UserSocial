using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserSocial.Core.Models.Domains;

namespace UserSocial.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Button> Buttons{ get; set; }
        public DbSet<LinkSocial> LinkSocials {  get; set; }
    }
}
