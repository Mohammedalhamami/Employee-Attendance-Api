﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeesLog.API.Data
{
    public class EmployeeLogAuthDbContext : IdentityDbContext
    {
        public EmployeeLogAuthDbContext(DbContextOptions<EmployeeLogAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                   Id = "484eb79f-5022-47b0-9de0-9f9f9d8b5340",
                   ConcurrencyStamp = "484eb79f-5022-47b0-9de0-9f9f9d8b5340",
                   Name = "Reader",
                   NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = "e17216c8-c1cb-4363-933f-9dc5d62c56c5",
                    ConcurrencyStamp = "e17216c8-c1cb-4363-933f-9dc5d62c56c5",
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
