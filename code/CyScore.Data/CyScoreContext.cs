using CyScore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data
{
    public class CyScoreContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<StationModel> Stations { get; set; }
        public DbSet<PolicyModel> Policies { get; set; }
        public DbSet<StationPolicyModel> StationsPolicies { get; set; }

        public CyScoreContext(DbContextOptions<CyScoreContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding policies
            modelBuilder.Entity<PolicyModel>().HasData(
                new PolicyModel { Id = 10, Description = "TEST DESC", Name = "TEST NAME" }
                );
            
        }
    }
}
