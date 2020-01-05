using AndroidApi.Data.Mapping;
using AndroidApi.Domain;
using AndroidApi.Domain.Models;
using AndroidApi.Domain.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<TaskTeam> taskTeams { get; set; }
        public DbSet<ToDoTask> tasks { get; set; }
        public DbSet<User> users { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TaskTeamConfig());
            builder.ApplyConfiguration(new TaskConfig());
            builder.ApplyConfiguration(new TaskTeamUserConfig());
            builder.ApplyConfiguration(new UserConfig());
        }
    }
}
