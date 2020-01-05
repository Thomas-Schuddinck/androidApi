using AndroidApi.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndroidApi.Data.Mapping
{
    public class TaskTeamConfig : IEntityTypeConfiguration<TaskTeam>
    {
        public void Configure(EntityTypeBuilder<TaskTeam> builder)
        {
            builder.ToTable("TaskTeam");
            builder.HasKey(tt => tt.TeamId);

            builder.HasMany(tt => tt.Tasks).WithOne().OnDelete(DeleteBehavior.Cascade);


        }
    }
}
