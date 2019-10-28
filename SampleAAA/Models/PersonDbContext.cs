using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAAA.Models
{
    public class PersonDbContext:IdentityDbContext<MyUser>
    {
        private readonly IConfiguration iconfiguration;

        public PersonDbContext(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(iconfiguration.GetConnectionString("MyCon"));

        }
        public DbSet<Person> People { get; set; }
    }
}
