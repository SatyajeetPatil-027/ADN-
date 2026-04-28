using campusMaintainance_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace campusMaintainance_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
    }
}