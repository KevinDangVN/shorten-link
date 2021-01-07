using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DBContext
{
    public class ShortenLinkContext : DbContext
    {
        public ShortenLinkContext(DbContextOptions<ShortenLinkContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<LinkDataModel> LinkDatas { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleModel>().HasData(new RoleModel()
            {
                Id = Guid.Parse("aeeccc6d-e50f-43d9-92cf-e5b89acb8c83"),
                RoleName = "Admin"
            }, new RoleModel
            {
                Id = Guid.Parse("6f6c4608-4b39-11eb-ae93-0242ac130002"),
                RoleName = "Employee"
            }
            );

            modelBuilder.Entity<EmployeeModel>().HasData(new EmployeeModel()
            {
                Id = Guid.Parse("ffbed34c-4b39-11eb-ae93-0242ac130002"),
                Email = "mail_1@mail.com",
                FullName = "Nguyen Van A",
                UserName = "user",
                Password = new PasswordHasher<object>().HashPassword(null, "user"),
                RoleId = Guid.Parse("6f6c4608-4b39-11eb-ae93-0242ac130002"),

            },
            new EmployeeModel
            {
                Id = Guid.Parse("ad7e7c58-4b3a-11eb-ae93-0242ac130002"),
                Email = "mail_2@mail.com",
                FullName = "Nguyen Van N",
                UserName = "admin",
                Password = new PasswordHasher<object>().HashPassword(null, "admin"),
                RoleId = Guid.Parse("aeeccc6d-e50f-43d9-92cf-e5b89acb8c83"),
            }
            );

            modelBuilder.Entity<LinkDataModel>().HasData(new LinkDataModel()
            {
                CreatedAt = DateTime.Now,
                EmployeeId = Guid.Parse("ffbed34c-4b39-11eb-ae93-0242ac130002"),
                FullLink = "https://www.google.com",
                ShortLink = "google",
                Id = Guid.Parse("867e6316-4b44-11eb-ae93-0242ac130002"),
                Count = 0,

            },
            new LinkDataModel
            {
                CreatedAt = DateTime.Now,
                EmployeeId = Guid.Parse("ffbed34c-4b39-11eb-ae93-0242ac130002"),
                FullLink = "https://www.uuidgenerator.net/version1",
                ShortLink = "uuidgen",
                Id = Guid.Parse("a63771fc-4b44-11eb-ae93-0242ac130002"),
                Count = 0,
            },
            new LinkDataModel
            {
                CreatedAt = DateTime.Now,
                EmployeeId = Guid.Parse("ffbed34c-4b39-11eb-ae93-0242ac130002"),
                FullLink = "https://thanhnien.vn/",
                ShortLink = "thanhnien",
                Id = Guid.Parse("a4a31ddf-d56a-4209-8030-d3a696edf8eb"),
                Count = 0,
            },
            new LinkDataModel
            {
                CreatedAt = DateTime.Now,
                EmployeeId = Guid.Parse("ffbed34c-4b39-11eb-ae93-0242ac130002"),
                FullLink = "https://www.uuidgenerator.net/version4",
                ShortLink = "uuidgen4",
                Id = Guid.Parse("11f7fba0-4b45-11eb-ae93-0242ac130002"),
                Count = 0,
            }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
