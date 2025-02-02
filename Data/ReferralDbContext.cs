using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReferralDbContext : DbContext
    {
        public ReferralDbContext(DbContextOptions<ReferralDbContext> options) : base(options) { }

        public DbSet<Referral> Referrals { get; set; }
        public DbSet<ReferralTracking> ReferralTracking { get; set; }
        public DbSet<ReferralReports> ReferralReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referral>()
                .Property(r => r.Status);

            modelBuilder.Entity<Referral>()
                .HasMany(r => r.Clicks)
                .WithOne(t => t.Referral)
                .HasForeignKey(t => t.ReferralId);

            modelBuilder.Entity<Referral>()
                .HasMany(r => r.ReferralReports)
                .WithOne(rr => rr.Referral)
                .HasForeignKey(f => f.ReferralId);


            modelBuilder.Entity<Referral>().HasData(
                new Referral { Id = 1, ReferrerUserId = "janedoe@nothingspecific.com", ReferralCode = "XY7G4D", Status = "Pending" },
                new Referral { Id = 2, ReferrerUserId = "johndoe@nothingspecific.com", ReferralCode = "AB8H5E", Status = "Pending" }
                );

            modelBuilder.Entity<ReferralTracking>().HasData(
                new ReferralTracking { Id = 1, ReferralId = 1, DeviceId = "device001", Source = "SMS", ClickedAt = DateTime.UtcNow },
                new ReferralTracking { Id = 2, ReferralId = 2, DeviceId = "device002", Source = "Email", ClickedAt = DateTime.UtcNow }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
