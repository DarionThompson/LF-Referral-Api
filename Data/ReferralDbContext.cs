using Data.Entities;
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

        public DbSet<Referrals> Referrals { get; set; }
        public DbSet<ReferralTracking> ReferralTracking { get; set; }
        public DbSet<ReferralReports> ReferralReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referrals>()
                .Property(r => r.Status);

            modelBuilder.Entity<Referrals>()
                .HasMany(r => r.Clicks)
                .WithOne(t => t.Referral)
                .HasForeignKey(t => t.ReferralId);

            modelBuilder.Entity<Referrals>()
                .HasMany(r => r.ReferralReports)
                .WithOne(rr => rr.Referral)
                .HasForeignKey(f => f.ReferralId);


            modelBuilder.Entity<Referrals>().HasData(
                new Referrals 
                { 
                    Id = 1, 
                    ReferrerUserId = "janedoe@nothingspecific.com", 
                    ReferralCode = "XY7G4D", 
                    Status = "Pending", 
                    RefferedTrackingId = new Guid("89562468-222a-4661-bee0-5d9b9749cd90"),
                    CreatedAt = DateTime.Now
                },
                new Referrals 
                { 
                    Id = 2, 
                    ReferrerUserId = "johndoe@nothingspecific.com",
                    ReferralCode = "AB8H5E", 
                    Status = "Pending", 
                    RefferedTrackingId = new Guid("26a3bd92-3917-401e-98c3-fd8f8d9d02b4"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 3,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    Status = "Redeemed",
                    RefferedTrackingId = new Guid("f273be35-eb54-4bb5-977c-31aec7506bad"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 4,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    Status = "Pending",
                    RefferedTrackingId = new Guid("995822ad-9064-425d-8a67-4aed6272c09b"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 5,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    Status = "Pending",
                    RefferedTrackingId = new Guid("7578daa8-8ad6-42f7-b46c-988a41bc6fd1"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 6,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    Status = "Redeemed",
                    RefferedTrackingId = new Guid("3adfad83-068d-4d9c-acea-881610593d06"),
                    CreatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<ReferralTracking>().HasData(
                new ReferralTracking { Id = 1, ReferralId = 1, DeviceId = "device001", Source = "SMS", ClickedAt = DateTime.UtcNow },
                new ReferralTracking { Id = 2, ReferralId = 2, DeviceId = "device002", Source = "Email", ClickedAt = DateTime.UtcNow }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
