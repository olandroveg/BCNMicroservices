using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDRF.Models;

namespace UDRF.Data
{
    public class BcNodeConfiguration : IEntityTypeConfiguration<BcNode>
    {
        public void Configure(EntityTypeBuilder<BcNode> builder)
        {
            builder.ToTable("BcNode");
            builder.HasKey(e => e.Id);
            builder.HasMany(e=> e.BcNodeContents).WithOne(e => e.Bcnode).HasForeignKey(e=>e.BcNodeId).OnDelete(DeleteBehavior.Cascade);

        }
    }
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Content");
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.BcNodeContents).WithOne(e => e.Content).HasForeignKey(e => e.ContentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Services).WithMany(e => e.Contents).HasForeignKey(e => e.ServicesId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class BcNodeContentConfiguration : IEntityTypeConfiguration<BcNodeContent>
    {
        public void Configure(EntityTypeBuilder<BcNodeContent> builder)
        {
            builder.ToTable("BcNodeContent");
            builder.HasKey(e => e.Id);
        }
    }

    public class ContentServicesConfiguration : IEntityTypeConfiguration<ContentServices>
    {
        public void Configure(EntityTypeBuilder<ContentServices> builder)
        {
            builder.ToTable("ContentServices");
            builder.HasKey(e => e.Id);
        }
    }
    public class RepeatScheduleConfiguration : IEntityTypeConfiguration<RepeatSchedule>
    {
        public void Configure(EntityTypeBuilder<RepeatSchedule> builder)
        {
            builder.ToTable("RepeatSchedule");
            builder.HasKey(e => e.Id);
        }
    }
    public class TimeScheduleConfiguration : IEntityTypeConfiguration<TimeSchedule>
    {
        public void Configure(EntityTypeBuilder<TimeSchedule> builder)
        {
            builder.ToTable("TimeSchedule");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.BcNodeContent).WithMany(e => e.TimeSchedules).HasForeignKey(e => e.BcNodeContentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.RepeatSchedule).WithOne(e => e.TimeSchedule).HasForeignKey(e => e.TimeSchduleId).OnDelete(DeleteBehavior.Cascade);
        }
    }

}
