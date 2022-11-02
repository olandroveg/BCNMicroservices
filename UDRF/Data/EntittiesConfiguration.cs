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
            builder.HasMany(e => e.InterfaceBcNodes).WithOne(e => e.BcNode).HasForeignKey(e => e.BcNodeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.InterfaceBcNodesCoreBcNodes).WithOne(e => e.BcNode).HasForeignKey(e => e.BcNodeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Place).WithMany(e => e.BcNodes).HasForeignKey(e => e.PlaceId).OnDelete(DeleteBehavior.Cascade);

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
    public class InterfaceBcNodeConfiguration : IEntityTypeConfiguration<InterfaceBcNode>
    {
        public void Configure(EntityTypeBuilder<InterfaceBcNode> builder)
        {
            builder.ToTable("InterfaceBcNode");
            builder.HasKey(e => e.Id);
        }
    }
    public class InterfacesConfiguration : IEntityTypeConfiguration<Interfaces>
    {
        public void Configure(EntityTypeBuilder<Interfaces> builder)
        {
            builder.ToTable("Interfaces");
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.InterfaceBcNodes).WithOne(e => e.Interfaces).HasForeignKey(e => e.InterfaceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class InterfBcNodeCoreConfiguration : IEntityTypeConfiguration<InterfBcNodeCore>
    {
        public void Configure(EntityTypeBuilder<InterfBcNodeCore> builder)
        {
            builder.ToTable("InterfBcNodeCore");
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.InterfaceBcNodesCoreBcNode).WithOne(e => e.InterfBcNodeCore).HasForeignKey(e => e.InterfBcNodeCoreId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class InterfaceBcNodesCoreBcNodeConfiguration : IEntityTypeConfiguration<InterfaceBcNodesCoreBcNode>
    {
        public void Configure(EntityTypeBuilder<InterfaceBcNodesCoreBcNode> builder)
        {
            builder.ToTable("InterfaceBcNodesCoreBcNode");
            builder.HasKey(e => e.Id);
        }

    }
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Place");
            builder.HasKey(e => e.Id);

        }
    }
    public class APImappingConfiguration : IEntityTypeConfiguration<APImapping>
    {
        public void Configure(EntityTypeBuilder<APImapping> builder)
        {
            builder.ToTable("APImapping");
            builder.HasKey(e => e.Id);

        }
    }
    public class NFmappingConfiguration : IEntityTypeConfiguration<NFmapping>
    {
        public void Configure(EntityTypeBuilder<NFmapping> builder)
        {
            builder.ToTable("NFmapping");
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Apis).WithOne(e => e.NF).HasForeignKey(e => e.NFId).OnDelete(DeleteBehavior.Cascade);

        }
    }
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("Token");
            builder.HasKey(e => e.Id);

        }
    }

}
