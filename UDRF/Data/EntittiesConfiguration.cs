using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDRF.Models;

namespace UDRF.Data
{
    public class BcnUserAccountConfiguration : IEntityTypeConfiguration<BcNode>
    {
        public void Configure(EntityTypeBuilder<BcNode> builder)
        {
            builder.ToTable("BcNode");
            builder.HasKey(e => e.Id);
            builder.HasMany(e=> e.BcNodeContents).WithOne(e => e.Bcnode).HasForeignKey(e=>e.BcNodeId).OnDelete(DeleteBehavior.Cascade);

        }
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Content");
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.BcNodeContents).WithOne(e => e.Content).HasForeignKey(e => e.ContentId).OnDelete(DeleteBehavior.Cascade);

        }
        public void Configure(EntityTypeBuilder<BcNodeContent> builder)
        {
            builder.ToTable("BcNodeContent");
            builder.HasKey(e => e.Id);
        }
    }
}
