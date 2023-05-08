using iDent.ModelLibrary.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace iDent.API.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Bank>? Banks { get; set; }
        public DbSet<AuditTrail>? AuditTrails { get; set; }
        public DbSet<Invitation>? Invitations { get; set; }
    }
}