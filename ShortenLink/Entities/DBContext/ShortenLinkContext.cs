using Entities.Model;
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

    }
}
