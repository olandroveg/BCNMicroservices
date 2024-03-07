﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OF.Models;

namespace OF.Data
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("Token");
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
    public class IDinNRFConfiguration : IEntityTypeConfiguration<IDinNRF>
    {
        public void Configure(EntityTypeBuilder<IDinNRF> builder)
        {
            builder.ToTable("IDinNRF");
            builder.HasKey(e => e.Id);

        }
    }

}
