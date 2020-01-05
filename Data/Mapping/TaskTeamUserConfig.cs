using AndroidApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Data.Mapping
{
    public class TaskTeamUserConfig : IEntityTypeConfiguration<TaskTeamUser>
    {
        public void Configure(EntityTypeBuilder<TaskTeamUser> builder)
        {
            builder.ToTable("TaskTeamUser");
            builder.HasKey(k => new { k.TaskTeamId, k.UserId });
            builder.HasOne(ttu => ttu.TaskTeam).WithMany(tt => tt.TaskTeamUsers).HasForeignKey(ttu => ttu.TaskTeamId);

        }
    }
}
