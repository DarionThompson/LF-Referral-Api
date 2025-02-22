﻿using Data.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referrals>()
                .Property(r => r.Status);


            modelBuilder.Entity<Referrals>().HasData(
                new Referrals 
                { 
                    Id = 1, 
                    ReferrerUserId = "janedoe@nothingspecific.com", 
                    ReferralCode = "XY7G4D", 
                    ReferredUserEmail = "joe@gmail.com",
                    Status = "Pending", 
                    RefferedTrackingId = new Guid("89562468-222a-4661-bee0-5d9b9749cd90"),
                    CreatedAt = DateTime.Now
                },
                new Referrals 
                { 
                    Id = 2, 
                    ReferrerUserId = "johndoe@nothingspecific.com",
                    ReferralCode = "AB8H5E",
                    ReferredUserEmail = "joe@gmail.com",
                    Status = "Pending", 
                    RefferedTrackingId = new Guid("26a3bd92-3917-401e-98c3-fd8f8d9d02b4"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 3,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    ReferredUserEmail = "joe@gmail.com",
                    Status = "Redeemed",
                    RefferedTrackingId = new Guid("f273be35-eb54-4bb5-977c-31aec7506bad"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 4,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    ReferredUserEmail = "Eli@gmail.com",
                    Status = "Pending",
                    RefferedTrackingId = new Guid("995822ad-9064-425d-8a67-4aed6272c09b"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 5,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    ReferredUserEmail = "kate@gmail.com",
                    Status = "Pending",
                    RefferedTrackingId = new Guid("7578daa8-8ad6-42f7-b46c-988a41bc6fd1"),
                    CreatedAt = DateTime.Now
                },
                new Referrals
                {
                    Id = 6,
                    ReferrerUserId = "janedoe@nothingspecific.com",
                    ReferralCode = "XY7G4D",
                    ReferredUserEmail = "bill@gmail.com",
                    Status = "Redeemed",
                    RefferedTrackingId = new Guid("3adfad83-068d-4d9c-acea-881610593d06"),
                    CreatedAt = DateTime.Now
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
